using System;

namespace Med.SafeValue
{
    /// <summary>
    /// Hides a float from cheating tools by making an offset to the value.
    /// </summary>
    public struct SafeLong
    {
        private long offset;
        private long value;
        private static Random rand = new Random();

        public SafeLong(long value)
        {
            offset = rand.Next(-1000, 1000);
            this.value = value + offset;
        }

        /// <summary>
        /// The value of this instance.
        /// </summary>
        public long Value
        {
            get => value - offset;
            set => this = new SafeLong(value);
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
        public static SafeLong operator +(SafeLong l1, SafeLong l2)
        {
            return new SafeLong(l1.Value + l2.Value);
        }
        public static SafeLong operator +(SafeLong l1, SafeInt i2)
        {
            return new SafeLong(l1.Value + i2.Value);
        }
        public static SafeLong operator +(SafeLong l1, SafeFloat f2)
        {
            return new SafeLong((long)Math.Round(l1.Value + f2.Value));
        }
        public static SafeLong operator ++(SafeLong l1)
        {
            return new SafeLong(l1.Value + 1);
        }
        public static SafeLong operator -(SafeLong l1, SafeLong l2)
        {
            return new SafeLong(l1.Value - l2.Value);
        }
        public static SafeLong operator -(SafeLong l1, SafeInt i2)
        {
            return new SafeLong(l1.Value - i2.Value);
        }
        public static SafeLong operator -(SafeLong l1, SafeFloat f2)
        {
            return new SafeLong((long)Math.Round(l1.Value - f2.Value));
        }
        public static SafeLong operator --(SafeLong l1)
        {
            return new SafeLong(l1.Value - 1);
        }
        public static SafeLong operator /(SafeLong l1, SafeLong l2)
        {
            return new SafeLong(l1.Value / l2.Value);
        }
        public static SafeLong operator /(SafeLong l1, SafeInt i2)
        {
            return new SafeLong(l1.Value / i2.Value);
        }
        public static SafeLong operator /(SafeLong l1, SafeFloat f2)
        {
            return new SafeLong((long)Math.Round(l1.Value / f2.Value));
        }
        public static SafeLong operator *(SafeLong l1, SafeLong l2)
        {
            return new SafeLong(l1.Value * l2.Value);
        }
        public static SafeLong operator *(SafeLong l1, SafeInt i2)
        {
            return new SafeLong(l1.Value * i2.Value);
        }
        public static SafeLong operator *(SafeLong l1, SafeFloat f2)
        {
            return new SafeLong((long)Math.Round(l1.Value * f2.Value));
        }
        public static SafeLong operator %(SafeLong l1, SafeLong l2)
        {
            return new SafeLong(l1.Value % l2.Value);
        }
        public static SafeLong operator %(SafeLong l1, SafeInt i2)
        {
            return new SafeLong(l1.Value % i2.Value);
        }
        public static SafeLong operator %(SafeLong l1, SafeFloat f2)
        {
            return new SafeLong((long)Math.Round(l1.Value % f2.Value));
        }
        public static bool operator ==(SafeLong l1, SafeLong l2)
        {
            return l1.Value == l2.Value;
        }
        public static bool operator !=(SafeLong l1, SafeLong l2)
        {
            return l1.Value != l2.Value;
        }
        public static bool operator ==(SafeLong l1, SafeInt i2)
        {
            return l1.Value == i2.Value;
        }
        public static bool operator !=(SafeLong l1, SafeInt i2)
        {
            return l1.Value != i2.Value;
        }
        public static bool operator ==(SafeLong l1, SafeFloat f2)
        {
            return l1.Value == f2.Value;
        }
        public static bool operator !=(SafeLong l1, SafeFloat f2)
        {
            return l1.Value != f2.Value;
        }
        public static bool operator >(SafeLong l1, SafeLong l2)
        {
            return l1.Value > l2.Value;
        }
        public static bool operator <(SafeLong l1, SafeLong l2)
        {
            return l1.Value < l2.Value;
        }
        public static bool operator >=(SafeLong l1, SafeLong l2)
        {
            return l1.Value >= l2.Value;
        }
        public static bool operator <=(SafeLong l1, SafeLong l2)
        {
            return l1.Value <= l2.Value;
        }
        public static bool operator >(SafeLong l1, SafeInt i2)
        {
            return l1.Value > i2.Value;
        }
        public static bool operator <(SafeLong l1, SafeInt i2)
        {
            return l1.Value < i2.Value;
        }
        public static bool operator >=(SafeLong l1, SafeInt i2)
        {
            return l1.Value >= i2.Value;
        }
        public static bool operator <=(SafeLong l1, SafeInt i2)
        {
            return l1.Value <= i2.Value;
        }
        public static bool operator >(SafeLong l1, SafeFloat f2)
        {
            return l1.Value > f2.Value;
        }
        public static bool operator <(SafeLong l1, SafeFloat f2)
        {
            return l1.Value < f2.Value;
        }
        public static bool operator >=(SafeLong l1, SafeFloat f2)
        {
            return l1.Value >= f2.Value;
        }
        public static bool operator <=(SafeLong l1, SafeFloat f2)
        {
            return l1.Value <= f2.Value;
        }
        #endregion
    }
}
