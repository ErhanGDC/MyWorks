﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PeopleContext ctx = new PeopleContext())
            {
                ctx.People.Add(new Person() { Id = 1, Name = "John Doe" });
                ctx.SaveChanges();
            }
            using (PeopleContext ctx = new PeopleContext())
            {
                Person person = ctx.People.SingleOrDefault(p => p.Id == 1);
                Console.WriteLine(person.Name);
            }
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PeopleContext : DbContext
    {
        public IDbSet<Person> People { get; set; }
    }
}
