using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class TruckInterface
    {
        public static void truckQuestions(Vehicle i_TheVehicle)
        {
            string isFreezeString;
            bool flagToHelp = true;
            bool isVolumeOfTruckOK;
            float volumeOfTheTruck;

            Console.WriteLine("Please enter 'Y' if the truck contains Freeze, 'N' for no");
            isFreezeString = Console.ReadLine();
            while (flagToHelp)
            {
                if (isFreezeString.Equals("Y") || isFreezeString.Equals("N"))
                {
                    if (isFreezeString.Equals("Y"))
                    {
                        (i_TheVehicle as Truck).SetIsCarryingToxicMaterials(true);
                        break;
                    }

                    (i_TheVehicle as Truck).SetIsCarryingToxicMaterials(false);
                    break;
                }

                Console.WriteLine("Invalid command entered, please enter only 'Y' or 'N'.");
                isFreezeString = Console.ReadLine();
            }

            Console.WriteLine("Please enter the truck volume");
            isVolumeOfTruckOK = float.TryParse(Console.ReadLine(), out volumeOfTheTruck);
            while (flagToHelp)
            {
                if (isVolumeOfTruckOK)
                {
                    try
                    {
                        (i_TheVehicle as Truck).SetVolumeOfCargo(volumeOfTheTruck);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid volume of cargo entered, please enter a valid volume cargo");
                }

                isVolumeOfTruckOK = float.TryParse(Console.ReadLine(), out volumeOfTheTruck);
            }
        }

    }
}
