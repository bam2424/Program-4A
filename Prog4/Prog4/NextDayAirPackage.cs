using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NextDayAirPackage : AirPackage
{
    private decimal _expressFee;

    public NextDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, decimal expFee)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
        ExpressFee = expFee;
    }

    public decimal ExpressFee
    {

        get
        {
            return _expressFee;
        }

        private set
        {
            if (value >= 0)
                _expressFee = value;
            else
                throw new ArgumentOutOfRangeException(nameof(ExpressFee), value,
                    $"{nameof(ExpressFee)} must be >= 0");
        }
    }

    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .35;
        const double WEIGHT_FACTOR = .25;
        const double HEAVY_FACTOR = .2;
        const double LARGE_FACTOR = .22;

        decimal cost;

        cost = (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight) + ExpressFee;

        if (IsHeavy())
            cost += (decimal)(HEAVY_FACTOR * Weight);
        if (IsLarge())
            cost += (decimal)(LARGE_FACTOR * TotalDimension);

        return cost;
    }

    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"NextDay{base.ToString()}{NL}Express Fee: {ExpressFee:C}";
    }
}
