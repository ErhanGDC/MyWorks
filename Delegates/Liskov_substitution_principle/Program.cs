using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_substitution_principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Square();
            rectangle.Width = 10;
            rectangle.Height = 5;
            Console.WriteLine(rectangle.Area);
        }
    }
    public class Rectangle
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Rectangle()
        {
            // TODO: Complete member initialization
        }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public int Area
        {
            get
            {
                return Height * Width;
            }
        }
    }

    public class Square : Rectangle
    {
        public Square():base()
        {

        }
        public override int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        public override int Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
