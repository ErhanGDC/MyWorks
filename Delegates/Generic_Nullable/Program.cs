﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Nullable
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    struct Nullable<T> where T : struct
    {
        private bool hasValue;
        private T value;

        public Nullable(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public bool HasValue { get { return this.hasValue; } }

        public T Value
        {
            get
            {
                if (!this.HasValue) throw new ArgumentException();
                return this.value;
            }
        }

        public T GetValueOrDefualt() { return this.value; }
    }

    class MyClass<T> where T : class,new()
    {
        public MyClass()
        { MyProperty = new T(); }
        T MyProperty { get; set; }

        public void MyBikeMethod<T>()
        {
            T defaultValue = default(T);
        }
        public void MyGenericMethod<T>()
        {
            T defaultValue = default(T);
        }
    }


}
