using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GroundPackage : Package
{

    public GroundPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
     
    }

    public int ZoneDistance
    {

        get
        {
            const int FIRST_DIGIT_FACTOR = 10000;
            int dist;

            dist = Math.Abs((OriginAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip / FIRST_DIGIT_FACTOR));

            return dist;
        }
    }

    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .15;
        const double WEIGHT_FACTOR = .07;

        return (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * (ZoneDistance + 1) * Weight);
    }

    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Ground{base.ToString()}{NL}Zone Distance: {ZoneDistance}";
    }
}

