using ConsoleUI.Actions;
using GarageLogic;
using GarageLogic.Exception;
using System;
using System.Collections.Generic;
using System.Text;
using static GarageLogic.eNum;
using static GarageLogic.VehicleFactory;

namespace ConsoleUI
{
    public class UserInterface
    {
        public static void RunGarage()
        {
            int count = 1;
            Console.WriteLine("Welcome to the garage. There are currently no vehicles.");
            Garage theGarage = new Garage();
            runMainMenu(theGarage, count);
        }

        private static void runMainMenu(Garage i_TheGarage, int i_NumberOfTimeCalled)
        {
            string mainMenu;
            int userChoice;
            bool userInputFlag;
            bool flagToHelp = true;

            if (i_NumberOfTimeCalled != 1)
            {
                Console.Clear();
            }

            i_NumberOfTimeCalled++;
            Console.WriteLine("What action would you like to do?");
            mainMenu = string.Format(@"{0}[1]Enter a new vehicle to the garage{0}[2]Display the vehicle's status in the garage
[3]Change a vehicle status{0}[4]Inflate the air-pressure to the maximum{0}[5]Fuel a vehicle{0}[6]Charge an electric vehicle{0}[7]Display all vehicle statistics{0}[8]Exit The Garage", Environment.NewLine);
            Console.WriteLine(mainMenu);
            userInputFlag = int.TryParse(Console.ReadLine(), out userChoice);
            while (flagToHelp)
            {
                if (userInputFlag)
                {
                    if (userChoice >= 1 && userChoice <= 8)
                    {
                        break;
                    }
                }

                Console.WriteLine("Invalid choice, try again");
                userInputFlag = int.TryParse(Console.ReadLine(), out userChoice);
            }

            switch (userChoice)
            {
                case 1:
                    VehicleInterface.enterANewVehicleToTheGarage(i_TheGarage);
                    Console.WriteLine(string.Format("{0}Thank you for the details, your car is being fixed..", Environment.NewLine));
                    break;
                case 2:
                    VehicleInterface.displaySpecificStatus(i_TheGarage);
                    break;
                case 3:
                    VehicleInterface.changeVehicleStatus(i_TheGarage, i_NumberOfTimeCalled);
                    break;
                case 4:
                    AirPressureInterface.inflateTireAirPressureToMax(i_TheGarage, i_NumberOfTimeCalled);
                    break;
                case 5:
                    GasInterface.gasAVehicle(i_TheGarage);
                    break;
                case 6:
                    ElectricInterface.chargeACar(i_TheGarage, i_NumberOfTimeCalled);
                    break;
                case 7:
                    VehicleInterface.displayVehicleDetails(i_TheGarage, ref i_NumberOfTimeCalled);
                    break;
                case 8:
                    flagToHelp = !flagToHelp;
                    break;
            }

            if (flagToHelp)
            {
                returnToMainMenu(i_TheGarage, i_NumberOfTimeCalled);
            }
        }

        public static void returnToMainMenu(Garage i_TheGarage, int i_NumberOfTimeCalled)
        {
            string userChoiceAfterAddedVehicle;

            Console.WriteLine("to return to the main menu, please press 'M' or 'm', or anything else to exit.");
            userChoiceAfterAddedVehicle = Console.ReadLine();
            if (userChoiceAfterAddedVehicle.Equals("M") || userChoiceAfterAddedVehicle.Equals("m"))
            {
                runMainMenu(i_TheGarage, i_NumberOfTimeCalled);
            }
        }

        public static void returnToMainMenuFromInside(Garage i_TheGarage, ref int i_TheNumberOfTimeMenuCalled, out string o_LicenseNumber)
        {
            Console.WriteLine(string.Format("Invalid License number entered.{0}to return to the main menu, please press 'M' or 'm'{0}Or try another license number.", Environment.NewLine));
            o_LicenseNumber = Console.ReadLine();
            if (o_LicenseNumber.Equals("M") || o_LicenseNumber.Equals("m"))
            {
                runMainMenu(i_TheGarage, i_TheNumberOfTimeMenuCalled);
            }
        }
    }
}
