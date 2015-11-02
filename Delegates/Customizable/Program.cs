using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizable
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Animals.Add(new Animal ("Kangaroo",10));
            zoo.Animals.Add(new Animal ("Mr Sea Lion",20));
            foreach (Animal item in zoo.Animals)
	{
		 Console.WriteLine(item.Name);
	}
            Console.ReadLine();
        }
    }
    //public class Collection<T> : IList<T>, ICollection<T>, IList, ICollection, IEnumerable
    //{
    //    protected virtual void ClearItems();
    //    protected virtual void InsertItem(int index, T item);
    //    protected virtual void RemoveItem(int index);
    //    protected virtual void SetItem(int index, T item);

    //    protected IList<T> Items { get; }
    //}

    public class Animal
    {
        public string Name;
        public int Popularity;

        public Animal(string name, int popularity) 
        {
            Name = name;
            Popularity = popularity;
        }
    }

    public class AnimalCollection : Collection<Animal>
    { 
    //AnimalCollection is already a fully functioning list of animals.
    //No extra code is required   
    }

    public class Zoo
    {//The class that will expose AnimalCollection
        // this would be typically have additional members
        public readonly AnimalCollection Animals = new AnimalCollection();
    }
}
