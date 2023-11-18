
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Prog4
{
    class TestParcels
    {

        static void Main(string[] args)
        {

            bool VERBOSE = false;


            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); 
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210);
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901);
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101);
            Address a5 = new Address("John Doe", "111 Market St.",
                "Jeffersonville", "IN", 47130);
            Address a6 = new Address("Jane Smith", "55 Hollywood Blvd.", "Apt. 9",
                "Los Angeles", "CA", 90212);
            Address a7 = new Address("Captain Robert Crunch", "21 Cereal Rd.", "Room 987",
                "Bethesda", "MD", 20810);
            Address a8 = new Address("Vlad Dracula", "6543 Vampire Way", "Apt. 1",
                "Bloodsucker City", "TN", 37210);

            Letter letter1 = new Letter(a1, a2, 3.95M);
            Letter letter2 = new Letter(a3, a4, 4.25M);
            GroundPackage gp1 = new GroundPackage(a5, a6, 14, 10, 5, 12.5);
            GroundPackage gp2 = new GroundPackage(a7, a8, 8.5, 9.5, 6.5, 2.5);
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a3, a5, 9.5, 6.0, 5.5,
                5.25, 5.25M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a2, a7, 10.5, 6.5, 9.5,
                15.5, 5.00M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a5, a7, 46.5, 39.5, 28.0,
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a8, a1, 15.0, 9.5, 6.5,
                75.5, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a6, a4, 12.0, 12.0, 6.0,
                5.5, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;

            parcels = new List<Parcel>();

            parcels.Add(letter1);
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);

            WriteLine("Original List:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("====================");
            }
            Pause();

            parcels.Sort();
            WriteLine("Sorted in Natural Order (Ascending by Cost):");
            WriteLine("========================");
            foreach (Parcel p in parcels)
            {
                if (VERBOSE)
                    WriteLine(p);
                else
                    WriteLine($"{p.CalcCost(),8:C}");
            }
            Pause();

            parcels.Sort(new DescendingByDestZipComparer());
            WriteLine("Sorted using first Comparer (Descending by Destination Zip):");
            WriteLine("========================");
            foreach (Parcel p in parcels)
            {
                if (VERBOSE)
                    WriteLine(p);
                else
                    WriteLine($"{p.DestinationAddress.Zip:D5}");
            }
            Pause();

            parcels.Sort(new TypeAndCostComparer());
            WriteLine("Sorted using EC Comparer (Ascending By Type Then Descending by Cost):");
            WriteLine("========================");
            foreach (Parcel p in parcels)
            {
                if (VERBOSE)
                    WriteLine(p);
                else
                    WriteLine($"{p.GetType().ToString(),-17} {p.CalcCost(),8:C}");
            }
        }

        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Clear();
        }
    }
}
