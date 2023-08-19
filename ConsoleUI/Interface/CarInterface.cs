using GarageLogic;
using GarageLogic.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.eNum;

namespace ConsoleUI.Actions
{
    class CarInterface
    {
        public static void carQuestions(Vehicle i_TheVehicle)
        {
            int howManyDoors;
            bool flagToHelp = true;
            bool isDoorOkay;

            Console.WriteLine("Please enter the number of doors your car has");
            Console.Write(Car.ShowNumberOfDoors());
            Console.WriteLine();
            isDoorOkay = int.TryParse(Console.ReadLine(), out howManyDoors);

            while (flagToHelp)
            {
                try
                {
                    if (isDoorOkay)
                    {
                        (i_TheVehicle as Car).SetDoors((eDoors)howManyDoors);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a correct number of doors from the list:");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Car.ShowNumberOfDoors());
                isDoorOkay = int.TryParse(Console.ReadLine(), out howManyDoors);
            }

            Console.WriteLine();
            Console.WriteLine("Please enter the color of your car");
            Console.Write(Car.ShowColorsOptions());
            Console.WriteLine();
            isDoorOkay = int.TryParse(Console.ReadLine(), out howManyDoors);

            while (flagToHelp)
            {
                try
                {
                    if (isDoorOkay)
                    {
                        (i_TheVehicle as Car).SetColor((eColors)howManyDoors);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a correct number of doors from the list:");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Car.ShowColorsOptions());
                isDoorOkay = int.TryParse(Console.ReadLine(), out howManyDoors);
            }

            Console.WriteLine();
        }

    }
}
