namespace CashDesk
{
    public class Coin
    {
        int value;

        private static int[] ValidCoins = new int[] { 1, 2, 5, 10, 20, 50, 100 };

        public Coin(int value)
        {
            this.value = value;
        }

        public int Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return string.Format("A {0}c coin", value);
        }

        public static explicit operator int (Coin coin)
        {
            return coin.value;
        }

        public override bool Equals(object obj)
        {
            return value == (obj as Coin).value;
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

        public static bool operator ==(Coin lhs, Coin rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Coin lhs, Coin rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool Validate(Coin coin)
        {
            for (int i = 0; i < ValidCoins.Length; i++)
            {
                if (ValidCoins[i] == coin.value)
                    return true;
            }

            return false;
        }
    }
}