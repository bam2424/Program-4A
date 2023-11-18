using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DescendingByDestZipComparer : Comparer<Parcel>
{

    public override int Compare(Parcel p1, Parcel p2)
    {
        int zip1;
        int zip2;

        if (p1 == null && p2 == null) 
            return 0;

        if (p1 == null)
            return -1;

        if (p2 == null)
            return 1;

        zip1 = p1.DestinationAddress.Zip;
        zip2 = p2.DestinationAddress.Zip;

        return (-1) * zip1.CompareTo(zip2);
    }
}
