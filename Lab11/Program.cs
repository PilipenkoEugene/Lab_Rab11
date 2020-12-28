using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fIn = new StreamReader("lr11_23.csv");
#if !DEBUG
            TextWriter saveOut = Console.Out;
            var newOut = new StreamWriter(@"lr11Output.txt");
            Console.SetOut(newOut);
#endif
            var all = new List<Person>();
            
            try
            {
                string line = fIn.ReadLine();
                while ((line = fIn.ReadLine()) != null)
                {
                    all.Add(new Person(line));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Всего сотрудников: {0}", all.Count);
            foreach (var p in all)
                Console.WriteLine(p);

            Console.WriteLine("********Задача 1 *********");
            var count = all.Where(x => x.Salary < x.ProductionAmount * x.ProductPrice).Count();
            Console.WriteLine("количество тех кто получает меньше чем вырабатывает: {0}", count);

            Console.WriteLine("********Задача 2 *********");
            var withoutType = all.Where(x => x.Product == null).Sum(x => x.ProductionAmount);
            Console.WriteLine("Количество выпущенных товаров без категории {0}", withoutType);

            Console.WriteLine("********Задача 3 *********");
            Console.WriteLine("Общая стоимость всех продуктов категории " + ProductType.Type1 + ": " +
                all.Where(x => x.Product == ProductType.Type1).Sum(x => x.ProductionAmount * x.ProductPrice));
            Console.WriteLine("Общая стоимость всех продуктов категории " + ProductType.Type2 + ": " +
                all.Where(x => x.Product == ProductType.Type2).Sum(x => x.ProductionAmount * x.ProductPrice));
            Console.WriteLine("Общая стоимость всех продуктов категории " + ProductType.Type3 + ": " +
                all.Where(x => x.Product == ProductType.Type3).Sum(x => x.ProductionAmount * x.ProductPrice));
            Console.WriteLine("Общая стоимость всех продуктов категории " + ProductType.Type4 + ": " +
                all.Where(x => x.Product == ProductType.Type4).Sum(x => x.ProductionAmount * x.ProductPrice));

            Console.WriteLine("********Задача 4 *********");
            Func<Person, float> getDiff = min => min.ProductionAmount * min.ProductPrice - min.Salary;
            var LeastEffective = all.Aggregate((mi, x) => getDiff(mi) < getDiff(x) ? mi : x);
            Console.WriteLine("Самый неэффективный сотрудник " + LeastEffective.ID);



#if !DEBUG
            Console.SetOut(saveOut);
            newOut.Close();
#else
            Console.ReadKey();
#endif
        }
    }
}
