using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class ElectricMotorcycleInterface
    {
        public static void electricMotorcycleQuestions(Vehicle i_TheVehicle)
        {
            MotorcycleInterface.motorcycleQuestions(i_TheVehicle);
            ElectricInterface.electricQuestions(i_TheVehicle);
        }
    }
}
