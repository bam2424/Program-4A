
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TwoDayAirPackage : AirPackage
{
    public enum Delivery { Early, Saver }

    private Delivery _deliveryType;

    public TwoDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, Delivery delType)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
        DeliveryType = delType;
    }

    public Delivery DeliveryType
    {
        get
        {
            return _deliveryType;
        }

        set
        {
            if (Enum.IsDefined(typeof(Delivery), value))
                _deliveryType = value;
            else
                throw new ArgumentOutOfRangeException(nameof(DeliveryType), value,
                    $"{nameof(DeliveryType)} must be {nameof(Delivery.Early)} " +
                    $"or {nameof(Delivery.Saver)}");
        }
    }

    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .18; 
        const double WEIGHT_FACTOR = .2; 
        const decimal DISCOUNT_FACTOR = .15M; 

        decimal cost;

        cost = (decimal)(DIM_FACTOR * TotalDimension + WEIGHT_FACTOR * Weight);

        if (DeliveryType == Delivery.Saver)
            cost *= (1-DISCOUNT_FACTOR);

        return cost;
    }

    public override string ToString()
    {
        string NL = Environment.NewLine;

        return $"TwoDay{base.ToString()}{NL}Delivery Type: {DeliveryType}";
    }
}
