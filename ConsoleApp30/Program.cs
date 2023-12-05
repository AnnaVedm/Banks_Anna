using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Анюткабанки
{
    class Program
    {
        static void Main(string[] args)
        {
            int id;
            string FIO;
            int accountNumber; //номер счета
            double dengi;

            Console.Write("Здравствуйте! Мы приветствуем вас в банке Анютка. Спасибо, что выбрали нас!");
            Console.Write("\nУкажите количество клиентов банка: ");
            int schetnumb = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();

            Bank[] schet = new Bank[schetnumb];
            Bank bank = new Bank();

            Console.WriteLine();
            for (int i = 0; i < schet.Length; i++)
            {
                Console.WriteLine($"Клиент {i + 1}");
                schet[i] = new Bank();

                id = i + 1;

                Console.Write("Введите ваше ФИО: ");
                FIO = Console.ReadLine();

                accountNumber = rnd.Next(123455600, 999927839);

                Console.Write("Укажите, сколько денег хотите положить на счет: ");
                dengi = Convert.ToDouble(Console.ReadLine());

                schet[i].Information(id, FIO, accountNumber, dengi);

                Console.WriteLine("\nИнформация о счете: ");
                schet[i].Otkryt_schet();

                Console.ReadKey();
                Console.Clear();
            }

            while (true)
            {
                Console.WriteLine("Выберите счёт, на который хотите зайти (Для выхода укажите 0): ");
                bank.schet_vybor(schet, schet.Length, schet.Length);

                int vybor = Convert.ToInt32(Console.ReadLine());

                if (vybor == 0)
                {
                    Console.WriteLine("Конец программы");
                    break;
                }
                else
                {
                    int schet_index = vybor - 1;

                    while (vybor > schet.Length || schet_index < 0)
                    {
                        Console.WriteLine("Такого счёта не существует. Попробуйте ввести снова: ");
                        vybor = Convert.ToInt32(Console.ReadLine());
                        schet_index = vybor - 1;                //Номер счёта как индекс в массиве
                    }

                    schet[schet_index].Otkryt_schet();

                    Console.WriteLine("\nВыберите действие:\n1.Положить деньги на счёт\n2.Снять деньги со счёта\n3.Обнулить счёт\n4.Перевести сумму с одного счёта на другой.\n5.Выход");
                    int actionChoice = Convert.ToInt32(Console.ReadLine());

                    schet[schet_index].vybory(schet, actionChoice, schet_index, vybor);
                }
            }
        }

        static void output(Bank[] accounts)
        {
            for (int i = 0; i < accounts.Length; i++) //Вывод каждого счёта
            {
                Console.WriteLine($"Счёт {i + 1}");
                accounts[i].Otkryt_schet();

                Console.WriteLine();
            }
        }
    }
}