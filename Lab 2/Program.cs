using System.Collections;

namespace lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle1 = new Rectangle(10, 2);
            Rectangle rectangle2 = new Rectangle(5, 8);
            Square square = new Square(4);
            Circle circle = new Circle(1);
            ArrayList arrayList = new ArrayList();
            arrayList.Add(rectangle1);
            arrayList.Add(rectangle2);
            arrayList.Add(square);
            arrayList.Add(circle);
            foreach (Shape shape in arrayList) { shape.Print(); }
        }
    }
}