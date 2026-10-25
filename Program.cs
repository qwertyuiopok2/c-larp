using System.Buffers;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace c_larp;

public class FuelType
{
    public int Number {get; private set;}
    public string? Fueltype {get; private set;}
    public double PricePerLitr {get; private set;}
    public double _fuelAvailable;

    public FuelType (int number, string? fueltype, double priceperlitr, double fuelavailable)
    {
        Number = number;
        Fueltype = fueltype;
        PricePerLitr = priceperlitr;
        _fuelAvailable = fuelavailable;
    }
}
public class GasStationManager
{
    List<FuelType> GasStation = new List<FuelType>()
    {
        new FuelType(1, "95", 70.5 , 400),
        new FuelType(2, "100", 120.4 , 200),
        new FuelType(3, "ДТ", 50.1 , 500),
        new FuelType(4, "92", 60.2 , 300),
        new FuelType(5, "Электро", 70.5 , 100)
    };
    public bool DispanceFuel(double litrs, string? type)
    {
        if (litrs < 0)
        {
            return false;
        }
        if (type == null)
        {
            return false;
        }
        List<FuelType> needcolonka = GasStation.Where(c => type == c.Fueltype).ToList();
        foreach(FuelType lox in needcolonka)
        {
            if(lox._fuelAvailable < litrs)
            {
                return false;
            }
            else
            {
                lox._fuelAvailable = lox._fuelAvailable - litrs * lox.PricePerLitr;
                return true;
            }
        }
    }
}