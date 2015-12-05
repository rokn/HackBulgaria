using System;

namespace MainProject
{
    public class Fraction
    {
        private double numerator;
        private double denominator;

        public double Numerator
        {
            get
            {
                return numerator;
            }

            set
            {
                numerator = value;
                Optimize();
            }
        }

        public double Denominator
        {
            get
            {
                return denominator;
            }

            set
            {
                if(value == 0)
                {
                    throw new InvalidOperationException("Denominator can't be 0");
                }
                denominator = value;
                Optimize();
            }
        }

        public Fraction(double numerator, double denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be 0");
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", numerator, denominator);
        }

        public override bool Equals(object obj)
        {
            return this.numerator == (obj as Fraction).Numerator && this.denominator == (obj as Fraction).Denominator;
        }

        public static bool operator ==(Fraction fr, Fraction fr2)
        {
            return fr.Equals(fr2);
        }

        public static bool operator !=(Fraction fr, Fraction fr2)
        {
            return !fr.Equals(fr2);
        }

        public static Fraction operator +(Fraction fr, Fraction fr2)
        {
            Fraction result = new Fraction(fr.Numerator, fr.Denominator);
            result.Numerator = fr2.Denominator + fr2.Numerator * fr.Denominator;
            result.Denominator *= fr2.Denominator;
            return result;
        }

        public static Fraction operator -(Fraction fr, Fraction fr2)
        {
            Fraction result = new Fraction(fr.Numerator, fr.Denominator);
            result.Numerator = fr2.Denominator - fr2.Numerator * fr.Denominator;
            result.Denominator *= fr2.Denominator;
            return result;
        }

        public static Fraction operator *(Fraction fr, Fraction fr2)
        {
            Fraction result = new Fraction(fr.Numerator, fr.Denominator);
            result.Numerator *= fr2.Numerator;
            result.Denominator *= fr2.Denominator;
            return result;
        }

        public static Fraction operator /(Fraction fr, Fraction fr2)
        {
            Fraction result = new Fraction(fr.Numerator, fr.Denominator);
            result.Numerator *= fr2.Denominator;
            result.Denominator *= fr2.Numerator;
            return result;
        }

        public static double operator +(Fraction fr, double numb)
        {
            return fr.Numerator / fr.Denominator + numb;
        }

        public static double operator -(Fraction fr, double numb)
        {
            return fr.Numerator / fr.Denominator - numb;
        }

        public static double operator *(Fraction fr, double numb)
        {
            return fr.Numerator / fr.Denominator * numb;
        }

        public static double operator /(Fraction fr, double numb)
        {
            return fr.Numerator / fr.Denominator / numb;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Numerator.GetHashCode();
                hash = hash * 23 + Denominator.GetHashCode();
                return hash;
            }
        }

        public static explicit operator double(Fraction fr)
        {
            return fr.Numerator / fr.Denominator;
        }

        private void Optimize()
        {
            for (double i = Math.Min(Numerator, Denominator); i >= 2; i--)
            {
                if(Numerator % i == 0 && Denominator % i == 0)
                {
                    Numerator /= i;
                    Denominator /= i;
                }
            }
        }
    }
}
