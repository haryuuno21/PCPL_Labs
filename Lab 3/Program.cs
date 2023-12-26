using FigureCollections;
using System.Collections;

namespace lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle1 = new Rectangle(10, 2);
            Rectangle rectangle2 = new Rectangle(5, 8);
            Square square = new Square(4);
            Circle circle = new Circle(1);

            Console.WriteLine("\n\t\t---ARRAYLIST---\n");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(rectangle1);
            arrayList.Add(rectangle2);
            arrayList.Add(square);
            arrayList.Add(circle);
            arrayList.Sort();
            foreach (Shape shape in arrayList) { shape.Print(); }

            Console.WriteLine("\n\t\t---LIST---\n");
            List<Shape> list = new List<Shape>();
            foreach (Shape shape in arrayList) { list.Add(shape); }
            list.Sort();
            foreach(Shape shape in list) { shape.Print(); };

            Console.WriteLine("\n\t\t---MATRIX---\n");
            Matrix<Shape> matrix = new Matrix<Shape>(3, 3, 3, new ShapeMatrixCheckEmpty());
            matrix[0, 0, 0] = rectangle1;
            matrix[1, 1, 1] = rectangle2;
            matrix[2, 2, 2] = square;
            matrix[1, 1, 0] = circle;
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("\t\t---STACK---\n");
            SimpleStack<Shape> stack = new SimpleStack<Shape>();
            stack.Push(rectangle1);
            stack.Push(rectangle2);
            stack.Push(square);
            stack.Push(circle);
            while(stack.Count > 0) {  Console.WriteLine(stack.Pop()); }
        }
    }
}