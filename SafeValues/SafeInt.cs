using System;

namespace Med.SafeValue
{
    /// <summary>
    /// Hides an integer from cheating tools by making an offset to the value.
    /// </summary>
    public struct SafeInt
    {
        private int offset;
        private int value;
        private static Random rand = new Random();

        public SafeInt(int value = 0)
        {
            offset = rand.Next(-1000, 1000);
            this.value = value + offset;
        }

        /// <summary>
        /// The value of this instance.
        /// </summary>
        public int Value
        {
            get => value - offset;
            set => this = new SafeInt(value);
        }

        /// <summary>
        /// Resets the value and the offset to 0.
        /// </summary>
        public void Reset()
        {
            offset = 0;
            value = 0;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
        #region Operators
        public static SafeInt operator +(SafeInt i1, SafeInt i2)
        {
            return new SafeInt(i1.Value + i2.Value);
        }
        public static SafeInt operator +(SafeInt i1, SafeFloat f2)
        {
            return new SafeInt((int)Math.Round(i1.Value + f2.Value));
        }
        public static SafeInt operator ++(SafeInt i1)
        {
            return new SafeInt(i1.Value + 1);
        }
        public static SafeInt operator -(SafeInt i1, SafeInt i2)
        {
            return new SafeInt(i1.Value - i2.Value);
        }
        public static SafeInt operator -(SafeInt i1, SafeFloat f2)
        {
            return new SafeInt((int)Math.Round(i1.Value - f2.Value));
        }
        public static SafeInt operator --(SafeInt i1)
        {
            return new SafeInt(i1.Value - 1);
        }
        public static SafeInt operator /(SafeInt i1, SafeInt i2)
        {
            return new SafeInt(i1.Value / i2.Value);
        }
        public static SafeInt operator /(SafeInt i1, SafeFloat f2)
        {
            return new SafeInt((int)Math.Round(i1.Value / f2.Value));
        }
        public static SafeInt operator *(SafeInt i1, SafeInt i2)
        {
            return new SafeInt(i1.Value * i2.Value);
        }
        public static SafeInt operator *(SafeInt i1, SafeFloat f2)
        {
            return new SafeInt((int)Math.Round(i1.Value * f2.Value));
        }
        public static SafeInt operator %(SafeInt i1, SafeInt i2)
        {
            return new SafeInt(i1.Value % i2.Value);
        }
        public static SafeInt operator %(SafeInt i1, SafeFloat f2)
        {
            return new SafeInt((int)Math.Round(i1.Value % f2.Value));
        }
        public static bool operator ==(SafeInt i1, SafeInt i2)
        {
            return i1.Value == i2.Value;
        }
        public static bool operator !=(SafeInt i1, SafeInt i2)
        {
            return i1.Value != i2.Value;
        }
        public static bool operator ==(SafeInt i1, SafeFloat f2)
        {
            return i1.Value == f2.Value;
        }
        public static bool operator !=(SafeInt i1, SafeFloat f2)
        {
            return i1.Value != f2.Value;
        }
        public static bool operator ==(SafeInt i1, SafeLong l2)
        {
            return i1.Value == l2.Value;
        }
        public static bool operator !=(SafeInt i1, SafeLong l2)
        {
            return i1.Value != l2.Value;
        }
        public static bool operator >(SafeInt i1, SafeInt i2)
        {
            return i1.Value > i2.Value;
        }
        public static bool operator <(SafeInt i1, SafeInt i2)
        {
            return i1.Value < i2.Value;
        }
        public static bool operator >=(SafeInt i1, SafeInt i2)
        {
            return i1.Value >= i2.Value;
        }
        public static bool operator <=(SafeInt i1, SafeInt i2)
        {
            return i1.Value <= i2.Value;
        }
        public static bool operator >(SafeInt i1, SafeFloat f2)
        {
            return i1.Value > f2.Value;
        }
        public static bool operator <(SafeInt i1, SafeFloat f2)
        {
            return i1.Value < f2.Value;
        }
        public static bool operator >=(SafeInt i1, SafeFloat f2)
        {
            return i1.Value >= f2.Value;
        }
        public static bool operator <=(SafeInt i1, SafeFloat f2)
        {
            return i1.Value <= f2.Value;
        }
        public static bool operator >(SafeInt i1, SafeLong l2)
        {
            return i1.Value > l2.Value;
        }
        public static bool operator <(SafeInt i1, SafeLong l2)
        {
            return i1.Value < l2.Value;
        }
        public static bool operator >=(SafeInt i1, SafeLong l2)
        {
            return i1.Value >= l2.Value;
        }
        public static bool operator <=(SafeInt i1, SafeLong l2)
        {
            return i1.Value <= l2.Value;
        }
        #endregion
    }
}
