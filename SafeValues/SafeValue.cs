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


        public SafeFloat(float value = 0)
        {
            var rand = new Random();
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
        public void Dispose()
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
    /// <summary>
    /// Hides an integer from cheating tools by making an offset to the value.
    /// </summary>
    public struct SafeInt
    {
        private int offset;
        private int value;

        public SafeInt(int value = 0)
        {
            var rand = new Random();
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
        public void Dispose()
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
    /// <summary>
    /// Hides a float from cheating tools by making an offset to the value.
    /// </summary>
    public struct SafeLong
    {
        private long offset;
        private long value;


        public SafeLong(long value)
        {
            var rand = new Random();
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
        public void Dispose()
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
