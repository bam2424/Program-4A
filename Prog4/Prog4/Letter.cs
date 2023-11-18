using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Letter : Parcel
{
    private decimal _fixedCost;

    public Letter(Address originAddress, Address destAddress, decimal cost)
        : base(originAddress, destAddress)
    {
        FixedCost = cost;
    }

    private decimal FixedCost
    {

        get
        {
            return _fixedCost;
        }

        set
        {
            if (value >= 0)
                _fixedCost = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(FixedCost)}", value,
                    $"{nameof(FixedCost)} must be >= 0");
        }
    }

    public override decimal CalcCost()
    {
        return FixedCost;
    }

    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"Letter{NL}{base.ToString()}";
    }
}
