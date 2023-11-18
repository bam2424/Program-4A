
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TypeAndCostComparer : Comparer<Parcel>
{
    public override int Compare(Parcel p1, Parcel p2)
    {
        string type1;
        string type2;

        if (this == null && p2 == null)
            return 0;

        if (this == null)
            return -1;

        if (p2 == null)
            return 1;

        type1 = p1.GetType().ToString();
        type2 = p2.GetType().ToString();

        if (type1 != type2)
            return type1.CompareTo(type2);

        return (-1)*p1.CompareTo(p2); 
    }
}
