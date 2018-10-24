using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Component disk = new Catalogue("Disk");
            Component catalogue = new Catalogue("Каталог");
            Component podkatalogue = new Catalogue("Подкаталог");
            Component jpeg_file = new File("Sun.jpeg");
            Component docx_file = new File("report.docx");
            Component html_file = new File("Site.html");
            Component podkatalog2 = new Catalogue("Подкаталог подкаталога");
            Component txt_file = new File("lab.txt");
            disk.Add(catalogue);
            catalogue.Add(jpeg_file);
            catalogue.Add(docx_file);
            catalogue.Add(podkatalogue);
            podkatalogue.Add(html_file);
            podkatalogue.Add(podkatalog2);
            podkatalog2.Add(txt_file);
            
            disk.Output();

            Console.ReadKey();
        }
    }

    abstract class Component
    {
        public string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { }
        public virtual void Output()
        {
            Console.WriteLine(name);
        }
    }
    class Catalogue : Component
    {
        private List<Component> components = new List<Component>();

        public Catalogue(string name)
            : base(name)
        {}

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Output()
        {
            Console.WriteLine(name);
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Output();
            }
        }
    }

    class File : Component
    {
        public File(string name)
            : base(name) { }
    }
}
