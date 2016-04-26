using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>() { 1, 3, 5 };
            myList[0] = 1;

            Duck.MyProperty = 0;
        }
    }
    public class Card
    {

    }
    class Deck
    {
        public int maximumNumberOfCards { get; set; }

        private int _maximumNumberOfCards;
        public List<Card> Cards { get; set; }
        public Deck(int maximumNumberOfCards)
        {
            this.maximumNumberOfCards = maximumNumberOfCards;
            Cards = new List<Card>();
        }// Rest of the class
    }
    public class Duck
    {
        public static int MyProperty { get; set; }
        public ICollection<Card> Cards { get; private set; }
    }
}
