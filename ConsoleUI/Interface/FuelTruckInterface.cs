using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class FuelTruckInterface
    {
        public static void fuelTruckQuestions(Vehicle i_TheVehicle)
        {
            TruckInterface.truckQuestions(i_TheVehicle);
            Console.WriteLine();
            FuelBasedInterface.fuelBasedQuestions(i_TheVehicle);
        }
    }
}
