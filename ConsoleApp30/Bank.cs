using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Анюткабанки
{
    class Bank
    {
        private int id;
        private string FIO;
        private int schet_number;
        private double dengi;

        public void Information(int id, string FIO, int schet_number, double dengi)
        {
            this.id = id;
            this.FIO = FIO;
            this.schet_number = schet_number;
            this.dengi = dengi;
        }

        public void schet_vybor(Bank[] schet, int j, int choice)//Вывод всех счетов
        {
            for (int i = 0; i < schet.Length; i++)
            {
                if (i == j) //Заход в аккаунт
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{schet[i].id}. {schet[i].FIO}, {schet[i].schet_number}");
                }
            }
        }

        public void vybory(Bank[] schet, int actionChoice, int accountIndex, int choice)
        {
            switch (actionChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали положить деньги на счёт");
                    schet[accountIndex].dob(schet, accountIndex);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали снять деньги со счёта");
                    schet[accountIndex].umen(schet, accountIndex);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали обнулить счёт.");
                    schet[accountIndex].obnul(schet, accountIndex);
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали перевести сумму с одного счёта на другой");
                    Console.WriteLine("Выберите счет для перевода: ");
                    schet_vybor(schet, accountIndex, choice);//Вывод всех счетов

                    int chooseToSend = Convert.ToInt32(Console.ReadLine());
                    int massiv_index = chooseToSend - 1;

                    schet[accountIndex].Perevod(schet, actionChoice, accountIndex, massiv_index);
                    break;

                case 5:
                    Console.WriteLine("Вы выбрали выйти");
                    Console.Clear();
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }

        private void Perevod(Bank[] accounts, int vybor, int schetIndex, int indexKonec)
        {
            Console.Write("Укажите, сколько хотите перевести: ");
            double sendMoney = Convert.ToDouble(Console.ReadLine());

            while (sendMoney < 0 || accounts[schetIndex].dengi < sendMoney)
            {
                Console.WriteLine("На вашем счетe не хватает денег. Попробуйте снова:");
                sendMoney = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Отправлено {sendMoney} руб");

            Console.WriteLine();

            Console.Write("Нажмите любую клавишу для вывода информации о счетах: ");
            Console.ReadKey();
            Console.Clear();

            accounts[schetIndex].dengi -= sendMoney; //Перевод
            accounts[indexKonec].dengi += sendMoney; //Получение

            Console.WriteLine("Информация о счете, на который переводились деньги: ");
            accounts[indexKonec].Otkryt_schet();

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Информация о счете, с которого переводились деньги: ");
            accounts[schetIndex].Otkryt_schet();

            Console.WriteLine();
        }

        private void obnul(Bank[] schet, int schetIndex)
        {
            schet[schetIndex].dengi = 0;
            Console.WriteLine($"теперь на вашем счете {schet[schetIndex].dengi} руб");

            Console.WriteLine();
        }

        private void dob(Bank[] schet, int schetIndex)
        {
            Console.Write("Укажите сумму для пополнения: ");
            double dob = Convert.ToDouble(Console.ReadLine());

            while (dob <= 0)
            {
                Console.WriteLine("Нельзя перевести отрицательное количество денег или равное 0. Попробуйте снова:");
                dob = Convert.ToDouble(Console.ReadLine());
            }

            schet[schetIndex].dengi += dob;
            Console.WriteLine($"Теперь на счетe {schet[schetIndex].dengi} руб");

            Console.WriteLine();
        }

        public void umen(Bank[] schet, int schet_index)
        {
            Console.Clear();
            Console.Write("Сколько денег вы хотите вывести со счёта?: ");
            double minus = Convert.ToDouble(Console.ReadLine());

            while (minus > schet[schet_index].dengi)
            {
                Console.WriteLine("У вас не хватает денег для вывода. Попробуйте выбрать сумму поменьше.");
                minus = Convert.ToDouble(Console.ReadLine());
            }

            schet[schet_index].dengi -= minus;

            Console.WriteLine($"Со счета выведено {minus} руб");
            Console.WriteLine($"Осталось {schet[schet_index].dengi} руб");

            Console.WriteLine();
        }

        public void Otkryt_schet()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"ФИО: {FIO}");
            Console.WriteLine($"Номер счета: {schet_number}");
            Console.WriteLine($"Средств на счете: {dengi} руб");
        }
    }
}
