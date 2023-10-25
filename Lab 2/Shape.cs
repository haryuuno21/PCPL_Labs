using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    interface IPrint
    {
        void Print();
    }

    abstract class Shape : IComparable, IPrint
    {
        public double Area { get; set; }
        public abstract double CalculateArea();
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            if (obj is Shape otherShape)
                return this.Area.CompareTo(otherShape.Area);
            else
                throw new ArgumentException("Object is not a Shape");
        }

        public abstract void Print();
    }

    class Rectangle : Shape
    {
        private double _width;
        private double _height;
        public double Width
        {
            get { return this._width; }
            set { this._width = (value > 0 ? value : 0); Area = CalculateArea(); }
        }
        public double Height
        {
            get { return this._height; }
            set { this._height = (value > 0 ? value : 0); Area = CalculateArea(); }
        }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return $"Rectangle: Width = {Width}, Height = {Height}, Area = {Area}";
        }

        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }

    class Square : Rectangle
    {
        public Square(double width) : base(width, width)
        {
        }
        public override string ToString()
        {
            return $"Square: Width = {Width}, Area = {Area}";
        }
    }

    class Circle : Shape
    {
        private double _radius;
        public double Radius
        {
            get { return this._radius; }
            set { this._radius = (value > 0 ? value : 0); Area = CalculateArea(); }
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override string ToString()
        {
            return $"Circle: Radius = {Radius}, Area = {Area}";
        }
        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
}
