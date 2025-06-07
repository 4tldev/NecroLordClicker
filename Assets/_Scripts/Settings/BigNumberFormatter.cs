using System;
using UnityEngine;

public static class BigNumberFormatter
{
    private static readonly string[] _baseSuffixes =
        { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };

    public static string Format(double number)
    {
        if (number < 1000)
            return number.ToString("F0"); // No decimals under 1K

        int magnitude = (int)Math.Floor(Math.Log10(number) / 3);

        double scaled = number / Math.Pow(1000, magnitude);

        string suffix = GetSuffix(magnitude);
        return scaled.ToString("F2") + suffix;
    }

    private static string GetSuffix(int magnitude)
    {
        if (magnitude < _baseSuffixes.Length)
            return _baseSuffixes[magnitude];

        // Calculate advanced suffix
        int offset = magnitude - _baseSuffixes.Length;

        // Tier 1: Aa–Zz
        if (offset < 26)
        {
            char c = (char)('A' + offset);
            return $"{c}z";
        }

        // Tier 2: AAa–ZZz
        offset -= 26;
        if (offset < 26)
        {
            char c = (char)('A' + offset);
            return $"{c}{c}z";
        }

        // Tier 3: AAAa–ZZZz
        offset -= 26;
        if (offset < 26)
        {
            char c = (char)('A' + offset);
            return $"{c}{c}{c}z";
        }

        return "[∞]"; // Fallback for ridiculous overflows
    }
}
