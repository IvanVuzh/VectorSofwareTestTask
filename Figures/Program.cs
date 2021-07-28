using System;
using System.Collections.Generic;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Rectangle(10, 10));
            shapes.Add(new Square(5));
            shapes.Add(new Triangle(10, 10));
            shapes.Add(new Circle(5));
            shapes.Add(new Rectangle(4, 3));
            shapes.Add(new Circle(100));
            shapes.Add(new Triangle(50, 3));
            shapes.Sort();
            foreach (var item in shapes)
            {
                Console.WriteLine(item);
                Console.WriteLine("Its area is ", item.Area());
            }
        }
    }

    abstract class Shape: IComparable
    {
        public abstract double Area();
        public int CompareTo(Shape other)
        {
            return this.Area().CompareTo(other.Area());
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Shape other = obj as Shape;
            if (other == null)
            {
                throw new ArgumentException("A IShape object is required for comparison.");
            }

            return CompareTo(other);
        }
        public abstract override string ToString();
        
    }

    class Square: Shape
    {
        public double A { get; set; }

        public Square(double a)
        {
            A = a;
        }
        public override double Area()
        {
            return A*A;
        }

        public override string ToString()
        {
            return $"Square with side {A}";
        }
    }

    class Rectangle : Shape
    {
        double a;
        double b;
        public double A 
        { 
            get { return a; }
            set { if (value > 0) a = value; }
        }
        public double B 
        { 
            get { return b; }
            set { if (value > 0) b = value; }
        }
        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }
        public override double Area()
        {
            return A * B;
        }

        public override string ToString()
        {
            return $"Rectangle with sides {A} and {B}";
        }
    }

    class Circle : Shape
    {
        double radius;
        public double Radius 
        { 
            get { return radius; }
            set { if( value > 0) radius = value; }
        }
        public Circle(double r)
        {
            Radius = r;
        }
        public override double Area()
        {
            return Radius * Math.PI;
        }

        public override string ToString()
        {
            return $"Circle with radius {Radius}";
        }
    }

    class Triangle : Shape
    {
        double a;
        double height;
        public double A 
        { 
            get { return a; } 
            set { if (value > 0) a = value; }
        }
        public double Height
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }
        public Triangle(double a, double h)
        {
            A = a;
            Height = h;
        }
        public override double Area()
        {
            return A * Height / 2;
        }

        public override string ToString()
        {
            return $"Triangle with base {A} and height {Height}";
        }
    }
}
