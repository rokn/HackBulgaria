using CashDesk;
using System;
using System.Collections.Generic;

namespace CashDeskApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Input a command:");

            bool exit = false;
            CashDesk.CashDesk desk = new CashDesk.CashDesk();

            do
            {
                string[] splited = Console.ReadLine().Split(' ');

                switch (splited[0])
                {
                    case "takebill":
                        desk.TakeMoney(new Bill(int.Parse(splited[1])));
                        break;

                    case "takebatch":
                        Bill[] batch = new Bill[splited.Length - 1];

                        for (int i = 0; i < batch.Length; i++)
                        {
                            batch[i] = new Bill(int.Parse(splited[i + 1]));
                        }

                        desk.TakeMoney(new BatchBill(batch));
                        break;

                    case "takecoin":
                        desk.TakeMoney(new Coin(int.Parse(splited[1])));
                        break;

                    case "takecoinbatch":
                        Coin[] coinBatch = new Coin[splited.Length - 1];

                        for (int i = 0; i < coinBatch.Length; i++)
                        {
                            coinBatch[i] = new Coin(int.Parse(splited[i + 1]));
                        }

                        desk.TakeMoney(new BatchCoin(coinBatch));
                        break;

                    case "total":
                        Console.WriteLine(desk.Total);
                        break;

                    case "inspect":
                        desk.Inspect();
                        break;

                    case "getchange":
                        List<Coin> change = new List<Coin>();

                        for (int i = 1; i < splited.Length; i++)
                        {
                            int value;

                            if(int.TryParse(splited[i], out value))
                            {
                                change.Add(new Coin(value));
                            }
                        }

                        var bestChange = desk.GiveChange(change);

                        break;
                        
                    case "exit":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }

            } while (!exit);
        }
    }
}
