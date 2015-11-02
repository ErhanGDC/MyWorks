using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Customizable1
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Animals.Add(new Animal("Kangaroo", 10));
            zoo.Animals.Add(new Animal("Mr Sea Lion", 20));
            foreach (Animal item in zoo.Animals)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
            zoo.Animals.Clear();
            foreach (Animal item in zoo.Animals)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    public class Animal
    {
        public string Name;
        public int Popularity;
        public Zoo Zoo { get; internal set; }
        public Animal(string name, int popularity)
        {
            Name = name;
            Popularity = popularity;
        }
    }

    public class AnimalCollection : Collection<Animal>
    {
        Zoo zoo;
        public AnimalCollection(Zoo zoo) { this.zoo = zoo; }

        protected override void InsertItem(int index, Animal item)
        {
            base.InsertItem(index, item);
            item.Zoo = zoo;
        }
        protected override void SetItem(int index,Animal item)
        {
            base.SetItem(index, item);
            item.Zoo = zoo;
        }
        protected override void RemoveItem(int index)
        {
            this[index].Zoo = null;
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (Animal a in this)
            {
                a.Zoo = null;
            }
            base.ClearItems();
        }
    }

    public class Zoo
    {
        public readonly AnimalCollection Animals;
        public Zoo() { Animals = new AnimalCollection (this); }
    }
}
