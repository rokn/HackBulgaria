namespace CashDesk
{
    public class Bill
    {
        int value;

        private static int[] ValidBills = new int[] { 2, 5, 10, 20, 50, 100 };

        public Bill(int value)
        {
            this.value = value;
        }

        public int Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return string.Format("A {0}$ bill", value);
        }

        public static explicit operator int(Bill bill)
        {
            return bill.value;
        }

        public override bool Equals(object obj)
        {
            return value == (obj as Bill).value;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + value.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Bill lhs, Bill rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Bill lhs, Bill rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool Validate(Bill bill)
        {
            for (int i = 0; i < ValidBills.Length; i++)
            {
                if (ValidBills[i] == bill.value)
                    return true;
            }

            return false;
        }
    }
}
