using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class FuelCarInterface
    {
        public static void fuelCarQuestions(Vehicle i_TheVehicle)
        {
            CarInterface.carQuestions(i_TheVehicle);
            FuelBasedInterface.fuelBasedQuestions(i_TheVehicle);
        }

    }
}
