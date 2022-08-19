using System;

namespace Med.SafeValue
{
    /// <summary>
    /// Hides a float from cheating tools by making an offset to the value.
    /// </summary>
    public struct SafeFloat
    {
        private float offset;
        private float value;
        private static Random rand = new Random();

        public SafeFloat(float value = 0)
        {
            offset = rand.Next(-1000, 1000);
            this.value = value + offset;
        }

        /// <summary>
        /// The value of this instance.
        /// </summary>
        public float Value
        {
            get => value - offset;
            set => this = new SafeFloat(value);
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
        public static SafeFloat operator +(SafeFloat f1, SafeFloat f2)
        {
            return new SafeFloat(f1.Value + f2.Value);
        }
        public static SafeFloat operator +(SafeFloat f1, SafeInt i2)
        {
            return new SafeFloat(f1.Value + i2.Value);
        }
        public static SafeFloat operator ++(SafeFloat f1)
        {
            return new SafeFloat(f1.Value + 1);
        }
        public static SafeFloat operator -(SafeFloat f1, SafeFloat f2)
        {
            return new SafeFloat(f1.Value - f2.Value);
        }
        public static SafeFloat operator -(SafeFloat f1, SafeInt i2)
        {
            return new SafeFloat(f1.Value - i2.Value);
        }
        public static SafeFloat operator --(SafeFloat f1)
        {
            return new SafeFloat(f1.Value - 1);
        }
        public static SafeFloat operator /(SafeFloat f1, SafeFloat f2)
        {
            return new SafeFloat(f1.Value / f2.Value);
        }
        public static SafeFloat operator /(SafeFloat f1, SafeInt i2)
        {
            return new SafeFloat(f1.Value / i2.Value);
        }
        public static SafeFloat operator *(SafeFloat f1, SafeFloat f2)
        {
            return new SafeFloat(f1.Value * f2.Value);
        }
        public static SafeFloat operator *(SafeFloat f1, SafeInt i2)
        {
            return new SafeFloat(f1.Value * i2.Value);
        }
        public static SafeFloat operator %(SafeFloat f1, SafeFloat f2)
        {
            return new SafeFloat(f1.Value % f2.Value);
        }
        public static SafeFloat operator %(SafeFloat f1, SafeInt i2)
        {
            return new SafeFloat(f1.Value % i2.Value);
        }
        public static bool operator ==(SafeFloat f1, SafeFloat f2)
        {
            return f1.Value == f2.Value;
        }
        public static bool operator !=(SafeFloat f1, SafeFloat f2)
        {
            return f1.Value != f2.Value;
        }
        public static bool operator ==(SafeFloat f1, SafeInt i2)
        {
            return f1.Value == i2.Value;
        }
        public static bool operator !=(SafeFloat f1, SafeInt i2)
        {
            return f1.Value != i2.Value;
        }
        public static bool operator ==(SafeFloat f1, SafeLong l2)
        {
            return f1.Value == l2.Value;
        }
        public static bool operator !=(SafeFloat f1, SafeLong l2)
        {
            return f1.Value != l2.Value;
        }
        public static bool operator >(SafeFloat f1, SafeFloat f2)
        {
            return f1.Value > f2.Value;
        }
        public static bool operator <(SafeFloat f1, SafeFloat f2)
        {
            return f1.Value < f2.Value;
        }
        public static bool operator >=(SafeFloat f1, SafeFloat f2)
        {
            return f1.Value >= f2.Value;
        }
        public static bool operator <=(SafeFloat f1, SafeFloat f2)
        {
            return f1.Value <= f2.Value;
        }
        public static bool operator >(SafeFloat f1, SafeInt i2)
        {
            return f1.Value > i2.Value;
        }
        public static bool operator <(SafeFloat f1, SafeInt i2)
        {
            return f1.Value < i2.Value;
        }
        public static bool operator >=(SafeFloat f1, SafeInt i2)
        {
            return f1.Value >= i2.Value;
        }
        public static bool operator <=(SafeFloat f1, SafeInt i2)
        {
            return f1.Value <= i2.Value;
        }
        public static bool operator >(SafeFloat f1, SafeLong l2)
        {
            return f1.Value > l2.Value;
        }
        public static bool operator <(SafeFloat f1, SafeLong l2)
        {
            return f1.Value < l2.Value;
        }
        public static bool operator >=(SafeFloat f1, SafeLong l2)
        {
            return f1.Value >= l2.Value;
        }
        public static bool operator <=(SafeFloat f1, SafeLong l2)
        {
            return f1.Value <= l2.Value;
        }
        #endregion
    }
}
