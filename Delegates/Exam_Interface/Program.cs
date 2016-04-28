using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = new Dog();

            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            IList<IEntity> col = new List<IEntity>();
            foreach (var item in col)
            {
                item.Add(list);
            }
            MyRepository<IEntity> entity = new MyRepository<IEntity>(col);
            Console.WriteLine(entity.FindById(5));

            Console.ReadLine();
        }
    }

    public interface IEntity : IList
    {
        int Id { get; }
    }

    public class MyRepository<T>
     where T : IEntity
    {
        protected IEnumerable<T> _elements;
        public MyRepository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }
    //The Repository base class offers a method for finding entities by ID. This code is generic and can be used by all entities. 
    //What if you want to add a specific query that would filter orders on date and amount? 
    //That wouldn’t be something that applied to all entities; only to the order entity. 
    //Using inheritance can help you reuse your code while adding some extra behavior.
    //Listing 2-46 shows how to inherit from a class.

    //class Order : IEntity
    //{
    //    public int Id { get; }
    //    // Other implementation details omitted
    //    // …
    //}
    //class OrderRepository : MyRepository<Order>
    //{
    //    public OrderRepository(IEnumerable<Order> orders)
    //        : base(orders) { }
    //    public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
    //    {
    //        List<Order> result = null;
    //        // Some filtering code
    //        return result;
    //    }
    //}

    interface IInterfaceA
    {
        void MyMethod();
    }
    class Implementation : IInterfaceA
    {
        void IInterfaceA.MyMethod() { }
    }
    interface ILeft
    {
        void Move();
    }
    interface IRight
    {
        void Move();
    }
    class MoveableOject : ILeft, IRight
    {
        void ILeft.Move() { }
        void IRight.Move() { }
    }

    interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get; set; }
    }
    class ExampleImplementation : IExample
    {
        public string GetResult()
        {
            return "result";
        }
        public int Value { get; set; }
        public event EventHandler CalculationPerformed;
        public event EventHandler ResultRetrieved;
        public int this[string index]
        {
            get
            {
                return 42;
            }
            set { }
        }
    }

    interface IReadOnlyInterface
    {
        int value { get; }
    }
    struct ReadAndWriteImplementation : IReadOnlyInterface
    {
        public int value
        {
            get { return value; }
            set { value = 5; }
        }
    }

    interface IRepoSitory<T>
    {
        T FindById(int id);
        IEnumerable<T> All();

        //void MoveAnimimal(IAnimal animal)
        //{
        //    animal.Move();
        //}
    }

    interface IAnimal
    {
        void Move();
    }
    class Dog : IAnimal
    {
        public void Move() { }
        public void Bark() { }
    }
}
