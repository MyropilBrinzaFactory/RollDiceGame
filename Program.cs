using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollDiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            Console.WriteLine("Добро пожаловать в кости.\nВаша цель выкинуть на кубиках больше, чем оппонент.\nВ игре есть система очков, за победу вы получаете 30 очков, ровно столько же у вас отнимается за поражение.\nВы стартуете с 0 очков.");
            Menu:
            Console.WriteLine("\nНа данный момент у Вас {0} очков.", points);
            Console.Write("\n1. Начать игру\nВыберите дальнейшее действие: ");
            string choose = Console.ReadLine();
            int n = int.Parse(choose);

            switch(n)
            {
                case 1:
                    bool result = DiceGame();
                    if (result == true)
                    {
                        points += 30;
                    }
                    else
                    {
                        points -= 30;
                    }
                    goto Menu;
                    break;

                default:
                    Console.WriteLine("\nВыбери правильный вариант.");
                    goto Menu;
                    break;
            }
        }

        public static bool DiceGame()
        {
        Restart:
            bool result;
            Random rnd = new Random();
            int pl1 = rnd.Next(0, 6);
            int pl2 = rnd.Next(0, 6);
            int op1 = rnd.Next(0, 6);
            int op2 = rnd.Next(0, 6);
            Console.WriteLine("\nРезультаты вашего броска: {0} и {1}", pl1, pl2);
            Console.WriteLine("Результаты броска оппонента: {0} и {1}", op1, op2);

            if (pl1 + pl2 > op1 + op2)
            {
                Console.WriteLine("\nВы выйграли! Добавлено 30 очков.");
                Console.ReadLine();
                Console.Clear();
                result = true;
                return result;
            }
            else if (pl1 + pl2 == op1 + op2)
            {
                Console.WriteLine("\nВыпали одинаковые числа. Переигровка.");
                Console.ReadLine();
                Console.Clear();
                goto Restart;
            }
            else
            {
                Console.WriteLine("\nВы проиграли. Снято 30 очков.");
                Console.ReadLine();
                Console.Clear();
                result = false;
                return result;
            }
        }
    }
}
