using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public enum ProductType
    {
        Type1,
        Type2,
        Type3,
        Type4
    }
    public class Person
    {
        public string ID { get; set; }
        string Fullname { get; set; }
        public ProductType? Product { get; set; }
        public float Salary { get; set; }
        public int ProductionAmount { get; set; }
        public int ProductPrice { get; set; }

        public Person(string str)
        {
            var e = str.Split(',');
            ID = e[0].Trim();
            Fullname = e[1].Trim();
            ProductType tmp;
            var result = Enum.TryParse(e[2].Trim(), out tmp);
            Product = tmp;
            if (!result)
                Product = null;
            Salary = Convert.ToSingle(e[3].TrimStart('$').Replace('.', ','));
            ProductionAmount = Convert.ToInt32(e[4].Trim());
            ProductPrice = Convert.ToInt32(e[5].Trim());
        }

        public override string ToString()
        {
            string s = string.Format(
                "*******************************************************\n" +
                "ID: {0}, Сотрудник: {1}, Категория продукта: {2}, Зарплата: {3}, Количество произведенных: {4}, Цена одного: {5})",
                ID, Fullname, Product.ToString(), Salary, ProductionAmount, ProductPrice);
            return s;
        }

    }
}
