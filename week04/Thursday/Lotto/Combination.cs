namespace Lotto
{
    public class Combination<T,U>
    {
        private T[] firstGroup;
        private U[] secondGroup;

        public Combination(T f1, T f2, T f3, U s1, U s2, U s3)
        {
            firstGroup = new T[3];
            firstGroup[0] = f1;
            firstGroup[1] = f2;
            firstGroup[2] = f3;
            secondGroup = new U[3];
            secondGroup[0] = s1;
            secondGroup[1] = s2;
            secondGroup[2] = s3;
        }
    }
}
