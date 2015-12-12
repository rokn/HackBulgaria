using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CashDesk
{
    public class BatchBill : IEnumerable
    {
        Bill[] bills;
        int total;

        public BatchBill(params Bill[] bills)
        {
            if (bills.Length <= 0)
                throw new ArgumentOutOfRangeException("There must be at least one bill");

            this.bills = bills;
            CalculateTotal();
        }

        public int Count
        {
            get { return bills.Length; }
        }

        public int TotalAmount
        {
            get { return total; }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Batch:[");

            for (int i = 0; i < bills.Length; i++)
            {
                builder.Append(bills[i].Value + "$");
                if (i < bills.Length - 1)
                    builder.Append(",");

            }

            builder.Append("]");

            return builder.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return bills.GetEnumerator();
        }

        private void CalculateTotal()
        {
            total = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                total += bills[i].Value;
            }
        }
    }
}
