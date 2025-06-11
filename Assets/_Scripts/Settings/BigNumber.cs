using System;

[System.Serializable]
public struct BigNumber : IComparable<BigNumber>
{
    public double mantissa;
    public int exponent;

    public BigNumber(double value)
    {
        if (value == 0)
        {
            mantissa = 0;
            exponent = 0;
            return;
        }

        exponent = (int)Math.Floor(Math.Log10(Math.Abs(value)));
        mantissa = value / Math.Pow(10, exponent);
        Normalize();
    }

    public static BigNumber From(double mantissa, int exponent)
    {
        var result = new BigNumber();
        result.mantissa = mantissa;
        result.exponent = exponent;
        result.Normalize();
        return result;
    }

    private void Normalize()
    {
        if (mantissa == 0)
        {
            exponent = 0;
            return;
        }

        int shift = (int)Math.Floor(Math.Log10(Math.Abs(mantissa)));
        mantissa *= Math.Pow(10, -shift);
        exponent += shift;
    }

    public double ToDouble()
    {
        return mantissa * Math.Pow(10, exponent);
    }

    public override string ToString()
    {
        return BigNumberFormatter.Format(ToDouble());
    }

    // Addition
    public static BigNumber operator +(BigNumber a, BigNumber b)
    {
        if (a.mantissa == 0) return b;
        if (b.mantissa == 0) return a;

        int diff = a.exponent - b.exponent;
        if (Math.Abs(diff) > 15) return (a.exponent > b.exponent) ? a : b;

        double newMantissa = a.mantissa + b.mantissa * Math.Pow(10, b.exponent - a.exponent);
        return From(newMantissa, a.exponent);
    }

    // Subtraction
    public static BigNumber operator -(BigNumber a, BigNumber b)
    {
        return a + (-b);
    }

    public static BigNumber operator -(BigNumber a)
    {
        return From(-a.mantissa, a.exponent);
    }

    // Multiplication
    public static BigNumber operator *(BigNumber a, double b)
    {
        return From(a.mantissa * b, a.exponent);
    }

    public static BigNumber operator *(BigNumber a, BigNumber b)
    {
        return From(a.mantissa * b.mantissa, a.exponent + b.exponent);
    }

    // Division
    public static BigNumber operator /(BigNumber a, BigNumber b)
    {
        return From(a.mantissa / b.mantissa, a.exponent - b.exponent);
    }

    public static BigNumber operator /(BigNumber a, double b)
    {
        return From(a.mantissa / b, a.exponent);
    }

    // Comparison
    public int CompareTo(BigNumber other)
    {
        if (exponent == other.exponent)
            return mantissa.CompareTo(other.mantissa);
        return exponent.CompareTo(other.exponent);
    }

    public static bool operator >(BigNumber a, BigNumber b) => a.CompareTo(b) > 0;
    public static bool operator <(BigNumber a, BigNumber b) => a.CompareTo(b) < 0;
    public static bool operator >=(BigNumber a, BigNumber b) => a.CompareTo(b) >= 0;
    public static bool operator <=(BigNumber a, BigNumber b) => a.CompareTo(b) <= 0;
    public static bool operator ==(BigNumber a, BigNumber b) => a.CompareTo(b) == 0;
    public static bool operator !=(BigNumber a, BigNumber b) => !(a == b);

    public override bool Equals(object obj)
    {
        if (!(obj is BigNumber)) return false;
        return this == (BigNumber)obj;
    }

    public override int GetHashCode()
    {
        return mantissa.GetHashCode() ^ exponent.GetHashCode();
    }

    public static BigNumber Pow(BigNumber baseValue, int exponent)
    {
        if (exponent == 0)
            return new BigNumber(1);

        BigNumber result = baseValue;

        for (int i = 1; i < exponent; i++)
        {
            result *= baseValue;
        }

        return result;
    }
}
