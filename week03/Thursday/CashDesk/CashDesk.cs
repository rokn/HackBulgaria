using System;
using System.Collections.Generic;
using System.Linq;

namespace CashDesk
{
    public class CashDesk
    {
        Dictionary<Bill, int> bills;
        Dictionary<Coin, int> coins;
        double total;

        public CashDesk()
        {
            bills = new Dictionary<Bill, int>();
            coins = new Dictionary<Coin, int>();
        }

        public double Total
        {
            get { return total; }
        }

        public string TotalMessage
        {
            get { return string.Format("We have a total of {0}$ in the desk", Total); }
        }

        public void TakeMoney(Bill bill)
        {
            if (!Bill.Validate(bill))
            {
                Console.WriteLine("The bill {0} is not valid! Unacceptablle!!!", (int)bill);
                return;
            }

            if (bills.ContainsKey(bill))
            {
                bills[bill]++;
            }
            else
            {
                bills.Add(bill, 1);
            }

            total += bill.Value;
        }

        public void TakeMoney(BatchBill batch)
        {
            foreach (Bill bill in batch)
            {
                TakeMoney(bill);
            }
        }

        public void TakeMoney(Coin coin)
        {
            if (!Coin.Validate(coin))
            {
                Console.WriteLine("The coin {0} is not valid! Unacceptablle!!!", (int)coin);
                return;
            }

            if (coins.ContainsKey(coin))
            {
                coins[coin]++;
            }
            else
            {
                coins.Add(coin, 1);
            }

            total += coin.Value / 100.0;
        }

        public void TakeMoney(BatchCoin batch)
        {
            foreach (Coin coin in batch)
            {
                TakeMoney(coin);
            }
        }

        public void Inspect()
        {
            Console.WriteLine("We have the following count of bills and coins, sorted in ascending order:");
            List<Bill> keys = bills.Keys.ToList();
            var ordered = keys.OrderBy(b => -b.Value);

            foreach (var key in ordered)
            {
                Console.WriteLine("{0}$ bills - {1}", (int)key, bills[key]);
            }

            List<Coin> coinKeys = coins.Keys.ToList();
            var coinsOrdered = coinKeys.OrderBy(c => c.Value);

            foreach (var key in coinsOrdered)
            {
                Console.WriteLine("{0}c coins - {1}", (int)key, coins[key]);
            }
        }

        public KeyValuePair<List<Bill>, List<Coin>> GiveChange(List<Coin> change)
        {
            int total = 0;

            foreach(var coin in change)
            {
                total += (int)coin;
            }

            var bestChange = CalculateBestChange(total);

            if ((bestChange.Key.Count <= 0 && bestChange.Value.Count > change.Count) ||
                bestChange.Key.Count <= 0 || bestChange.Value.Count <= 0)
                return new KeyValuePair<List<Bill>, List<Coin>>(new List<Bill>(), change);
            else
                return bestChange;
        }

        private KeyValuePair<List<Bill>, List<Coin>> CalculateBestChange(int total, List<Coin> additionalChange = null)
        {
            List<Bill> changeBills = new List<Bill>();
            List<Coin> changeCoins = new List<Coin>();

            List<Bill> keys = bills.Keys.ToList();
            List<Bill> ordererdKeys = new List<Bill>();
            var orderedBills = keys.OrderBy(b => -b.Value);

            foreach (var key in orderedBills)
            {
                ordererdKeys.Add(key);
            }

            int i = 0;

            while (i < ordererdKeys.Count)
            {
                if ((int)ordererdKeys[i] * 100 < total)
                {
                    changeBills.Add(ordererdKeys[i]);
                    bills[ordererdKeys[i]]--;
                    total -= (int)ordererdKeys[i] * 100;

                    if (bills[ordererdKeys[i]] < 0)
                    {
                        bills.Remove(ordererdKeys[i]);
                    }

                    i--;
                }

                i++;
            }


            List<Coin> coinsKeys = coins.Keys.ToList();
            List<Coin> coinsKeysOrdered = new List<Coin>();
            var orderedCoins = coinsKeys.OrderBy(b => -b.Value);
            coinsKeys.Clear();
            foreach (var key in orderedCoins)
            {
                coinsKeys.Add(key);
            }

            i = 0;

            while (i < coinsKeys.Count)
            {                                
                if ((int)coinsKeys[i] < total)
                {
                    changeCoins.Add(coinsKeys[i]);
                    coins[coinsKeys[i]]--;
                    total -= (int)coinsKeys[i];

                    if (coins[coinsKeys[i]] < 0)
                    {
                        coins.Remove(coinsKeys[i]);
                    }

                    i--;
                }

                i++;
            }

            if(additionalChange != null)
            {
                additionalChange = 
            }

            return new KeyValuePair<List<Bill>, List<Coin>>(changeBills, changeCoins);
        }
    }
}
