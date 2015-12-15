using System;
using System.Text;

namespace MainProject
{
    public class Vector
    {
        private readonly double[] _coordinates;
        
        public Vector(params double[] coordinates)
        {
            if (coordinates.Length <= 0)
                throw new ArgumentOutOfRangeException("There must be at least one dimension");
            this._coordinates = coordinates;
        }

        public Vector(Vector vector)
        {
            _coordinates = new double[vector.Dimensions];
            int i = 0;
            foreach(double coord in vector._coordinates)
            {
                _coordinates[i++] = coord;
            }
        }

        public double this[int i]
        {
            get
            {
                return _coordinates[i];
            }
            set
            {
                _coordinates[i] = value;
            }
        }

        public int Dimensions
        {
            get
            {
                return _coordinates.Length;
            }
        }

        public double Length
        {
            get
            {
                double length = 0;

                for (int i = 0; i < Dimensions; i++)
                {
                    length += Math.Pow(_coordinates[i], 2);
                }

                return Math.Sqrt(length);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            for (int i = 0; i < Dimensions; i++)
            {
                builder.Append(String.Format("{0}, ", _coordinates[i]));
            }
            builder.Remove(builder.Length - 2, 2);
            builder.Append(")");
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            Vector other = obj as Vector;
            if (other == null || other.Dimensions != this.Dimensions)
                return false;

            for (int i = 0; i < Dimensions; i++)
            {
                if(_coordinates[i] != other._coordinates[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            return ReferenceEquals(v1, v2);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !ReferenceEquals(v1, v2);
        }

        public static Vector operator +(Vector lhs, Vector rhs)
        {
            if (lhs.Dimensions != rhs.Dimensions)
                throw new ArgumentOutOfRangeException("Vectors must be of the same length");

            double[] newCoords = new double[lhs.Dimensions];

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                newCoords[i] = lhs[i] + rhs[i];
            }

            return new Vector(newCoords);
        }

        public static Vector operator -(Vector lhs, Vector rhs)
        {
            if (lhs.Dimensions != rhs.Dimensions)
                throw new ArgumentOutOfRangeException("Vectors must be of the same length");

            double[] newCoords = new double[lhs.Dimensions];

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                newCoords[i] = lhs[i] - rhs[i];
            }

            return new Vector(newCoords);
        }

        public static Vector operator +(Vector lhs, double rhs)
        {
            double[] newCoords = new double[lhs.Dimensions];

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                newCoords[i] = lhs[i] + rhs;
            }

            return new Vector(newCoords);
        }

        public static Vector operator -(Vector lhs, double rhs)
        {
            double[] newCoords = new double[lhs.Dimensions];

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                newCoords[i] = lhs[i] - rhs;
            }

            return new Vector(newCoords);
        }

        public static Vector operator *(Vector lhs, double rhs)
        {
            double[] newCoords = new double[lhs.Dimensions];

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                newCoords[i] = lhs[i] * rhs;
            }

            return new Vector(newCoords);
        }

        public static Vector operator /(Vector lhs, double rhs)
        {
            double[] newCoords = new double[lhs.Dimensions];

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                newCoords[i] = lhs[i] / rhs;
            }

            return new Vector(newCoords);
        }

        public static double operator *(Vector lhs, Vector rhs)
        {
            if (lhs.Dimensions != rhs.Dimensions)
                throw new ArgumentOutOfRangeException("Vectors must be of the same length");

            double result = 0;

            for (int i = 0; i < lhs.Dimensions; i++)
            {
                result += lhs[i] * rhs[i];
            }

            return result;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _coordinates.GetHashCode();
                return hash;
            }
        }
    }
}
