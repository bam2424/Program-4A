using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Address
{
    public const int MIN_ZIP = 0;
    public const int MAX_ZIP = 99999;

    private string _name;
    private string _address1;
    private string _address2;
    private string _city;
    private string _state;
    private int _zip;

    public Address(string name, string address1, string address2,
        string city, string state, int zipcode)
    {
        Name = name;
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        Zip = zipcode;
    }

    public Address(string name, string address1, string city,
        string state, int zipcode) :
        this(name, address1, string.Empty, city, state, zipcode)
    {
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(Name)}",
                    value, $"{nameof(Name)} must not be empty");
            else
                _name = value.Trim();
        }
    }

    public string Address1
    {
        get
        {
            return _address1;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(Address1)}",
                    value, $"{nameof(Address1)} must not be empty");
            else
                _address1 = value.Trim();
        }
    }

    public string Address2
    {

        get
        {
            return _address2;
        }

        set
        {
            if (value == null)
                value = string.Empty;

            _address2 = value.Trim();
        }
    }

    public string City
    {

        get
        {
            return _city;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(City)}",
                    value, $"{nameof(City)} must not be empty");
            else
                _city = value.Trim();
        }
    }

    public string State
    {

        get
        {
            return _state;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException($"{nameof(State)}",
                    value, $"{nameof(State)} must not be empty");
            else
                _state = value.Trim();
        }
    }

    public int Zip
    {

        get
        {
            return _zip;
        }

        set
        {
            if ((value >= MIN_ZIP) && (value <= MAX_ZIP))
                _zip = value;
            else
                throw new ArgumentOutOfRangeException($"{nameof(Zip)}", value,
                    $"{nameof(Zip)} must be U.S. 5 digit zip code");
        }
    }

    public override string ToString()
    {
        string NL = Environment.NewLine;
        string result;
        result = $"{Name}{NL}{Address1}{NL}";

        if (!string.IsNullOrWhiteSpace(Address2))
            result += $"{Address2}{NL}";

        result += $"{City}, {State} {Zip:D5}";
        return result;
    }
}