using System;

namespace Calc
{
    internal class Calc
    {
        public Calc()
        {
        }

        internal object Sum(int v1, int v2)
        {
            return v1 + v2;
        }
        internal object Raz(int v1, int v2)
        {
            return v1 - v2;
        }
        internal object Umn(int v1, int v2)
        {
            return v1 * v2;
        }
        internal object Step(int v1, int v2)
        {
            return Math.Pow(v1, v2);
        }
        internal object Factor(int v1)
        {
            return 120;
        }
    }
}