using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AirPackage : Package
{
    public const double HEAVY_THRESHOLD = 75;
    public const double LARGE_THRESHOLD = 100;

    public AirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
    }

    public bool IsHeavy()
    {
        return (Weight >= HEAVY_THRESHOLD);
    }

    public bool IsLarge()
    {
        return (TotalDimension >= LARGE_THRESHOLD);
    }

    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Air{base.ToString()}{NL}Heavy: {IsHeavy()}{NL}Large: {IsLarge()}";
    }
}
