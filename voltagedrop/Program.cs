using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace voltagedrop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объявление переменных
            double b, un = 0, Ib = 0;
            Console.WriteLine("Введите напряжение: ");
            int U0 = int.Parse(Console.ReadLine());
            switch (U0)
            {
                case 220:
                    b = 2;
                    un = 0.22;
                    break;
                case 380:
                    b = 1;
                    un = 0.38;
                    break;
                default:
                    Console.WriteLine("Вводите напряжение в вольтах - 220 или 380");
                    b = 0;
                    break;
            }
            // double cosf = 0.9, L = 66, S = 2.5, Ib = 6.3;
            Console.WriteLine("Введите мощность в кВт: ");
            double Pp = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите косинус: ");
            double cosf = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите длину линии: ");
            double L = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите сечение жилы: ");
            double S = double.Parse(Console.ReadLine());
            switch (U0)
            {
                case 220:
                    Ib = Pp / (cosf * un);
                    break;
                case 380:
                    Ib = Pp / (cosf * un * Math.Sqrt(3));
                    break;
            }
            double ro = 0.0225, lambda = 0.00008;
            double u, dU;
            // Вычисление падения напряжения
            u = b * (ro * (L / S) * Math.Cos(cosf) +
                     lambda * L * Math.Sin(cosf)) * Ib;
            // Приведение к процентам
            dU = 100 * (u / U0);
            Console.WriteLine("Потеря напряжения составляет: " + Math.Round(dU, 2, MidpointRounding.AwayFromZero) + " %");
            Console.ReadKey();
        }
    }
}
