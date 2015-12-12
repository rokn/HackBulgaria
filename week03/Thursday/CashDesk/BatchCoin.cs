using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CashDesk
{
    public class BatchCoin : IEnumerable
    {
        Coin[] coins;
        int total;

        public BatchCoin(params Coin[] coins)
        {
            if (coins.Length <= 0)
                throw new ArgumentOutOfRangeException("There must be at least one coin");

            this.coins= coins;
            CalculateTotal();
        }

        public int Count
        {
            get { return coins.Length; }
        }

        public int TotalAmount
        {
            get { return total; }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Batch:[");

            for (int i = 0; i < coins.Length; i++)
            {
                builder.Append(coins[i].Value + "c");
                if (i < coins.Length - 1)
                    builder.Append(",");

            }

            builder.Append("]");

            return builder.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return coins.GetEnumerator();
        }

        private void CalculateTotal()
        {
            total = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                total += coins[i].Value;
            }
        }
    }
}
