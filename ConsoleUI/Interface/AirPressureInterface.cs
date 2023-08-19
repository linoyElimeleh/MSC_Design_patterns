using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Actions
{
    class AirPressureInterface
    {
        public static void inflateTireAirPressureToMax(Garage i_TheGarage, int i_TheNumberOfTimeMenuCalled)
        {
            Console.Clear();
            Console.WriteLine("Please enter your license number");
            string licenseNumber = Console.ReadLine();
            bool flagToHelp = true;
            Vehicle theVehicleToInflateTo;
            string messageToUser;

            while (flagToHelp && !(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                if (i_TheGarage.IsVehicleInGarage(licenseNumber))
                {
                    Console.WriteLine("alright, the vehicle is in the garage.");
                    theVehicleToInflateTo = i_TheGarage.GetVehicle(licenseNumber);

                    foreach (Wheel oneWheel in theVehicleToInflateTo.GetWheels())
                    {
                        oneWheel.SetMaxPressure();
                    }

                    break;
                }
                else
                {
                    messageToUser = "Invalid license number or the vehicle isn't in the garage...Please enter a new license number";
                    messageToUser += Environment.NewLine;
                    messageToUser += "or press 'M' to return to the main menu";
                }

                UserInterface.returnToMainMenuFromInside(i_TheGarage, ref i_TheNumberOfTimeMenuCalled, out licenseNumber);
            }

            if (!(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                messageToUser = string.Format("Vehicle number {0} wheels has been inflated to the maximum", licenseNumber);
                Console.WriteLine(messageToUser);
            }
        }

    }
}
