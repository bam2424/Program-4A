using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Parcel : IComparable<Parcel>
{

    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        get;
        set;
    }

    public Address DestinationAddress
    {
        get;
        set;
    }

    public abstract decimal CalcCost();

    public override String ToString()
    {
        string NL = Environment.NewLine;

        return $"Origin Address:{NL}{OriginAddress}{NL}{NL}Destination Address:{NL}" +
            $"{DestinationAddress}{NL}Cost: {CalcCost():C}";
    }

    public int CompareTo(Parcel p2)
    {
        decimal cost1;
        decimal cost2;

        if (p2 == null)
            return 1;
        cost1 = this.CalcCost();
        cost2 = p2.CalcCost();

        return cost1.CompareTo(cost2);
    }
}
