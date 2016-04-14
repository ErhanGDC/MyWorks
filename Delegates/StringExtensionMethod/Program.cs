using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Account BankAccount = new Account
            {
                AccountID = 1080,
                Balance = 1454,
                Owner = "Erhan"
            };

            //Aşırı yükleyip extension haline getirilmiş toString Methodu
            Console.WriteLine(
                BankAccount.ToString(new string[] { "AccountID", "Owner", "Balance", "NaN" }));

            Console.WriteLine(BankAccount.ToString());
            Console.ReadLine();
        }
    }
    public static class StringExtensions
    {
        public static string ToString<T>(this T instance, params string[] propertyNames)
        {
            StringBuilder builder = new StringBuilder();
            T sample = (T)instance;
            foreach (var PropertyName in propertyNames)
            {
                if (sample.GetType().GetProperty(PropertyName) != null)
                {
                    builder.AppendFormat("{0}:{1}", PropertyName, sample.GetType().GetProperty(PropertyName).GetValue(instance).ToString());
                }
            }
            return builder.ToString();
        }

    }
}
