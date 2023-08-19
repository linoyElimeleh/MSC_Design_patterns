using GarageLogic;
using GarageLogic.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class FuelBasedInterface
    {
        public static void fuelBasedQuestions(Vehicle i_TheVehicle)
        {
            bool flagToHelp = true;
            bool isCurrentFuelOk;
            float currentFuelLevel;

            Console.WriteLine("Please enter the current fuel in the vehicle");
            isCurrentFuelOk = float.TryParse(Console.ReadLine(), out currentFuelLevel);
            while (flagToHelp)
            {
                if (isCurrentFuelOk)
                {
                    try
                    {
                        (i_TheVehicle.GetEnergyType() as Fuel).SetCurrentFuelTank(currentFuelLevel);
                        i_TheVehicle.SetPercentagesOfEnergyRemaining(Vehicle.ReimaingEnergyPercentage(currentFuelLevel, (i_TheVehicle.GetEnergyType() as Fuel).GetMaxTank()));
                        break;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a correct format of fuel level");
                }

                isCurrentFuelOk = float.TryParse(Console.ReadLine(), out currentFuelLevel);
            }
        }

    }
}
