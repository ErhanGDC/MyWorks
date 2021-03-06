﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exto
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conversions
            Money m = new Money(42.42M);
            decimal amount = m;
            int truncatedAmount = (int)m;



            Calculator ca = new Calculator();
            Console.WriteLine(ca.CalculateDiscount(new Prodcut() { Price = 10 }));
            Console.WriteLine(string.Concat("To box or not box", 42, true));

            Console.WriteLine("-----------------------------------");

            Celal cel = new Celal() { Yas = 35 };
            Console.WriteLine(cel.Yas);

            Console.WriteLine(YasDegis(cel));

            Console.WriteLine(cel.Yas);
            Console.Read();

            Object stream = new MemoryStream();
            MemoryStream memoryStream = (MemoryStream)stream;
            double x = 1234.7;
            int a;
            // Cast double to int            
            a = (int)x; // a = 1234
        }
        public static int YasDegis(Celal par)
        {
            return par.Yas = 30;
        }

    }
    public class Prodcut
    {
        public decimal Price { get; set; }
    }
    public static class MyExtensions
    {
        public static decimal Discount(this Prodcut pro)
        {
            return pro.Price * 0.9M;
        }
    }
    public class Calculator
    {
        public decimal CalculateDiscount(Prodcut p)
        {
            return p.Discount();
        }
    }


    //Overiding Methods
    class Base
    {
        public virtual int MyMethod()
        {
            return 42;
        }
    }
    class Derived : Base
    {
        public override int MyMethod()
        {
            return base.MyMethod() * 2;
        }
    }
    class Derived2 : Derived
    {
        // This line would give a compile error
        public override int MyMethod() { return 1; }
    }
    public struct Celal
    {
        public int Yas
        {
            //get { return this.Yas; }
            //set { this.Yas = 26; }
            get;
            set;
        }
    }
    class Money
    {
        public Money(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; set; }
        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }
        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }
    public class Base1
    {
        private int _privateField = 42;
        protected int _protectedField = 42;
        private void MyPrivateMethod() { }
        protected void MyProtectedMethod() { }
    }
    public class Derived1 : Base1
    {
        public void MyDerivedMethod()
        {
            // _privateField = 41; // Not OK, this will generate a compile error
            _protectedField = 43; // OK, protected fields can be accessed
            // MyPrivateMethod(); // Not OK, this will generate a compile error
            MyProtectedMethod(); // OK, protected methods can be accessed
        }
    }
    internal class MyInternalClass
    {
        public void MyMethod() { }
    }
    class Person
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                _firstName = value;
            }
        }      
    }
    class People
    {
        private string _pro;
        public string pro
        {
            get { return _pro; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException();
                _pro = value;
            }
        }
    }
}
