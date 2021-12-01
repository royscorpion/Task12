using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Моделирование объекта окружности при помощи классов
            #region Ввод исходных данных с проверкой их корректности
            Console.WriteLine("Демонстрация вывода методов статического класса Circle");
            Console.Write("Введите радиус круга (r): ");
            InputRadius(out double radius);
            Console.Write("Введите координаты центра круга\ncX = ");
            InputNumber(out double centerX);
            Console.Write("cY = ");
            InputNumber(out double centerY);
            Console.Write("Введите координаты точки для проверки ее попадания внутрь круга\npX = ");
            InputNumber(out double pointX);
            Console.Write("pY = ");
            InputNumber(out double pointY);
            #endregion

            #region Вывод результатов применения методов
            Console.WriteLine("\nМетод Circumference(r)\nДлина окружности с радиусом {0} : {1}",radius, Circle.Circumference(radius));
            Console.WriteLine("\nМетод Area(r)\nПлощадь круга с радиусом {0} : {1}", radius, Circle.Area(radius));
            Console.WriteLine("\nМетод PointInCircle(r,cx,cy,px,py)");
            if (Circle.PointInCircle(radius,centerX,centerY,pointX,pointY))
                Console.WriteLine("Точка ({0};{1}) принадлежит кругу радиусом {2} с центром ({3};{4})", pointX,pointY, radius,centerX,centerY);
            else
                Console.WriteLine("Точка ({0};{1}) не принадлежит кругу радиусом {2} с центром ({3};{4})", pointX, pointY, radius, centerX, centerY);
            #endregion

            Console.ReadKey();
        }

        //Проверка корректности введенных данных
        static void InputNumber(out double number)
        {
            number = 0;
            bool x;
            do
            {
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                    x = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}\nПопробуйте еще раз\n", ex.Message);
                    Console.Write("Введите число: ");
                    x = true;
                }
            } while (x);
        }
        static void InputRadius(out double number)
        {
            number = 0;
            bool x;
            do
            {
                try
                {
                    if((number = Convert.ToDouble(Console.ReadLine())) <= 0)
                    {
                        Console.WriteLine("Радиус не может быть отрицательным и равным нулю\nПопробуйте еще раз");
                        Console.Write("Введите положительное число: ");
                        x = true;
                    }
                    else 
                        x = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}\nПопробуйте еще раз\n", ex.Message);
                    Console.Write("Введите число: ");
                    x = true;
                }
            } while (x);
        }

    }

    //Определение статического класса Circle
    public static class Circle
    {
        public static double Circumference(double radius)
        {
            double circumference = 2 * Math.PI * radius;
            return circumference;
        }

        public static double Area(double radius)
        {
            double area = Math.PI * radius * radius;
            return area;
        }

        public static bool PointInCircle(double radius, double cx, double cy, double px, double py)
        {
            bool pointinside = (Math.Sqrt(Math.Pow((px - cx),2) + Math.Pow((py - cy),2)))<radius;
            return pointinside;
        }
    }
}
