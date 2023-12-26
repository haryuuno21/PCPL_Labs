using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Lab5_Reflection
{
    internal class Program
    {
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object? attribute)
        {
            bool Result = false;
            attribute = null;

            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }
        static void Main(string[] args)
        {
            Class ClassObject = new Class();
            Type t = ClassObject.GetType();

            Console.WriteLine("\nКонструкторы:");
            foreach (var constructor in t.GetConstructors())
            {
                Console.WriteLine(constructor);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var method in t.GetMethods())
            {
                Console.WriteLine(method);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var property in t.GetProperties())
            {
                Console.WriteLine(property);
            }

            Console.WriteLine("\nПоля:");
            foreach (var field in t.GetFields())
            {
                Console.WriteLine(field);
            }

            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                if (GetPropertyAttribute(x, typeof(MyAttribute), out object? attributeObject))
                {
                    MyAttribute? attribute = attributeObject as MyAttribute;
                    Console.WriteLine(x.Name + " - " + attribute?.Description);
                }
            }

            Console.WriteLine("\nВызов метода:");
            Class? fi = (Class?)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, Array.Empty<object>());
            object[] parameters = new object[] { 15, 4 };
            object? Result = t.InvokeMember("Minus", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Minus(15,4) = " + Result);
        }
    }
}