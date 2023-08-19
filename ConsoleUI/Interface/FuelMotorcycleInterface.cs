using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class FuelMotorcycleInterface
    {
        public static void fuelMotorcycleQuestions(Vehicle i_TheVehicle)
        {
            MotorcycleInterface.motorcycleQuestions(i_TheVehicle);
            FuelBasedInterface.fuelBasedQuestions(i_TheVehicle);
        }

    }
}
