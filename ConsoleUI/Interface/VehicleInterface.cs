using ConsoleUI.Actions;
using GarageLogic;
using GarageLogic.Exception;
using System;
using System.Collections.Generic;
using System.Text;
using static GarageLogic.eNum;

namespace ConsoleUI
{
    public class VehicleInterface
    {
        public static void enterANewVehicleToTheGarage(Garage i_TheGarage)
        {
            Console.Clear();
            bool flagToHelp = true;
            Console.WriteLine("\nPlease enter the license number of your vehicle");
            string i_LicenseNumber = Console.ReadLine();
            int TypeOfVehicle;
            bool flagOfOkType;

            while (flagToHelp)
            {
                if (ValidateLicenseNumber(i_LicenseNumber))
                {
                    break;
                }

                Console.WriteLine("Invalid license number, please try again");
                i_LicenseNumber = Console.ReadLine();
            }

            Console.WriteLine(string.Format("{0}Please choose the Vehicle Type", Environment.NewLine));
            string VehicleTypes = VehicleFactory.ShowVehicleTypes();
            Console.WriteLine(VehicleTypes);
            flagOfOkType = int.TryParse(Console.ReadLine(), out TypeOfVehicle);
            while (flagToHelp)
            {
                if (ValidateTypeOfVehicle(TypeOfVehicle) && flagOfOkType)
                {
                    break;
                }

                Console.WriteLine("Invalid license number, please try again");
                flagOfOkType = int.TryParse(Console.ReadLine(), out TypeOfVehicle);
            }

            if (i_TheGarage.IsVehicleInGarage(i_LicenseNumber))
            {
                Console.WriteLine("Vehicle is already in the garage, switching the vehicle status to repair");
                i_TheGarage.ChangeCarStatus(i_LicenseNumber, eVehicleStatus.inRepair);
            }
            else
            {
                Vehicle oneVehicle = VehicleFactory.CreateVehicle(i_LicenseNumber, (eVehicleType)TypeOfVehicle);
                i_TheGarage.EnterANewVehicleToTheGarage(oneVehicle);
                Console.WriteLine(string.Format("{0}Please enter your name", Environment.NewLine));
                string customerName = Console.ReadLine();
                int countName = 0;

                while (flagToHelp)
                {
                    countName = 0;
                    foreach (char oneChar in customerName)
                    {
                        if (char.IsLetter(oneChar))
                        {
                            countName++;
                        }
                    }

                    if (countName == customerName.Length)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid name, please enter only letters for your name..");
                        customerName = Console.ReadLine();
                    }
                }

                Console.WriteLine(string.Format("{0}Please enter your phone number", Environment.NewLine));
                string customerPhoneNumber = Console.ReadLine();
                int countDigitsOfPhoneNumber;

                while (flagToHelp)
                {
                    countDigitsOfPhoneNumber = 0;
                    foreach (char oneChar in customerPhoneNumber)
                    {
                        if (char.IsDigit(oneChar))
                        {
                            countDigitsOfPhoneNumber++;
                        }
                    }

                    if (countDigitsOfPhoneNumber == customerPhoneNumber.Length && customerPhoneNumber.Length > 7)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number, please enter only digits for your phone number..");
                        customerPhoneNumber = Console.ReadLine();
                    }
                }

                Customer c1 = new Customer(customerName, customerPhoneNumber, i_TheGarage.GetVehicle(i_LicenseNumber));
                //todo add something with this customer or not
                askAndUpdateGeneralVehicleQuestions(i_TheGarage.GetVehicle(i_LicenseNumber));
                getAllVehicleWiseDetails(i_TheGarage.GetVehicle(i_LicenseNumber), (eVehicleType)TypeOfVehicle);
            }
        }

        public static void displayVehicleDetails(Garage i_TheGarage, ref int i_TheNumberOfTimeMenuCalled)
        {
            Console.Clear();
            Console.WriteLine("Please enter your license number");
            string licenseNumber = Console.ReadLine();
            bool flagToHelp = true;
            Vehicle theVehicleToString;
            string messageToUser = "";

            while (flagToHelp && !(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                if (i_TheGarage.IsVehicleInGarage(licenseNumber))
                {
                    theVehicleToString = i_TheGarage.GetVehicle(licenseNumber);
                    messageToUser = theVehicleToString.ToString();
                    break;
                }
                else
                {
                    UserInterface.returnToMainMenuFromInside(i_TheGarage, ref i_TheNumberOfTimeMenuCalled, out licenseNumber);
                }
            }

            if (!(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                Console.WriteLine(messageToUser);
            }
        }

        public static void changeVehicleStatus(Garage i_TheGarage, int i_TheNumberOfTimeMenuCalled)
        {
            Console.Clear();
            Console.WriteLine("Please enter your license number");
            string licenseNumber = Console.ReadLine();
            bool flagToHelp = true;

            while (flagToHelp)
            {
                if (i_TheGarage.IsVehicleInGarage(licenseNumber))
                {
                    Console.WriteLine("alright, the vehicle is in the garage.");
                    bool theNewStateFlag;
                    int theNewState;
                    Console.WriteLine("Please enter the new desired state");
                    Console.WriteLine(Garage.ShowVehicleStatus());
                    theNewStateFlag = int.TryParse(Console.ReadLine(), out theNewState);
                    eVehicleStatus v1;
                    string messageToUser = "";

                    if (theNewStateFlag)
                    {
                        try
                        {
                            i_TheGarage.IsRangeOfVehicleStatus(theNewState, out v1);
                            i_TheGarage.ChangeCarStatus(licenseNumber, v1);
                            break;
                        }
                        catch (Exception ex)
                        {
                            if (ex is ArgumentException)
                            {
                                messageToUser = "The vehicle is already with the status you choosed, please choose different status.";
                            }
                            else
                            {
                                messageToUser = ex.Message;
                            }
                        }
                    }
                    else
                    {
                        messageToUser = string.Format("Invalid input, please try again and choose a type");
                    }

                    Console.WriteLine(messageToUser);
                    Console.WriteLine(Garage.ShowVehicleStatus());
                    theNewStateFlag = int.TryParse(Console.ReadLine(), out theNewState);
                }
                else
                {
                    UserInterface.returnToMainMenuFromInside(i_TheGarage, ref i_TheNumberOfTimeMenuCalled, out licenseNumber);
                }
            }

            Console.WriteLine("The new status has been saved.");
        }

        public static void displaySpecificStatus(Garage i_TheGarage)
        {
            Console.Clear();
            bool isStatusOk;
            int theStatus;
            bool flagToHelp = true;
            eVehicleStatus v1;
            string messageToUser = "";

            StringBuilder VehicleMessage = new StringBuilder();
            Console.WriteLine("Please choose which status would you like to see:");
            Console.WriteLine(Garage.ShowVehicleStatus());
            Console.WriteLine(string.Format("[{0}] All", Enum.GetValues(typeof(eVehicleStatus)).Length + 1));
            isStatusOk = int.TryParse(Console.ReadLine(), out theStatus);

            while (flagToHelp)
            {
                if (isStatusOk)
                {
                    try
                    {
                        i_TheGarage.IsRangeOfVehicleStatus(theStatus, out v1);
                        messageToUser = displayVehicleStatus(i_TheGarage, v1);

                        break;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        if (theStatus == Enum.GetValues(typeof(eVehicleStatus)).Length + 1)
                        {
                            flagToHelp = !flagToHelp;
                            foreach (eVehicleStatus status in Enum.GetValues(typeof(eVehicleStatus)))
                            {
                                VehicleMessage.Append(displayVehicleStatus(i_TheGarage, status));
                            }
                            break;
                        }
                        else
                        {
                            messageToUser = ex.Message;
                            messageToUser += Environment.NewLine;
                            messageToUser += "Please enter a valid status";
                        }
                    }
                }
                else
                {
                    messageToUser = "Invalid input entered, please enter a range number..";
                }

                Console.WriteLine(messageToUser);
                isStatusOk = int.TryParse(Console.ReadLine(), out theStatus);
            }
            if (flagToHelp)
            {
                Console.WriteLine(messageToUser);
            }
            else
            {
                Console.WriteLine(VehicleMessage.ToString());
            }
        }

        public static string displayVehicleStatus(Garage i_TheGarage, eVehicleStatus i_TheVehicleStatus)
        {
            List<Vehicle> theListToPrint;
            StringBuilder theMessageToPrint = new StringBuilder();

            theListToPrint = i_TheGarage.DisplayCarStatus(i_TheVehicleStatus);
            foreach (Vehicle licenseN in theListToPrint)
            {
                theMessageToPrint.Append(string.Format("The status of the vehicle with license number {0} is: {1}{2}", licenseN.GetLicenseNumber(), i_TheVehicleStatus.ToString(), Environment.NewLine));
            }

            return theMessageToPrint.ToString();
        }


        private static void askAndUpdateGeneralVehicleQuestions(Vehicle i_TheVehicleToAskFor)
        {
            string WheelManu, ModelName;
            float WheelsPressure;
            bool flagToHelp = true;
            Console.WriteLine();
            Console.WriteLine("Please enter the wheel manufacturer");
            WheelManu = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the current wheels pressure");
            bool isAirPressure = float.TryParse(Console.ReadLine(), out WheelsPressure);
            StringBuilder airPressureMessage;

            while (flagToHelp)
            {
                if (isAirPressure)
                {
                    airPressureMessage = new StringBuilder();
                    try
                    {
                        foreach (Wheel oneWheel in i_TheVehicleToAskFor.GetWheels())
                        {
                            oneWheel.InflatingAirPressure(WheelsPressure);
                            oneWheel.SetManufactureName(WheelManu);
                        }

                        break;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        airPressureMessage.Append(string.Format("Invalid air pressure, the correct airpressure is in range of {0} - {1}", ex.GetMinValue(), ex.GetMaxValue()));
                        Console.WriteLine(airPressureMessage.ToString());
                        isAirPressure = float.TryParse(Console.ReadLine(), out WheelsPressure);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter correct air pressure value");
                    isAirPressure = float.TryParse(Console.ReadLine(), out WheelsPressure);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Please enter the vehicle model name");
            ModelName = Console.ReadLine();
            i_TheVehicleToAskFor.SetModelName(ModelName);
            Console.WriteLine();

        }

        private static void getAllVehicleWiseDetails(Vehicle i_TheVehicleToAskFor, eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.MotorcycleElectric:
                    ElectricMotorcycleInterface.electricMotorcycleQuestions(i_TheVehicleToAskFor);
                    break;
                case eVehicleType.MotorcycleFuel:
                    FuelMotorcycleInterface.fuelMotorcycleQuestions(i_TheVehicleToAskFor);
                    break;
                case eVehicleType.CarElectric:
                    ElectricCarInterface.electricCarQuestions(i_TheVehicleToAskFor);
                    break;
                case eVehicleType.CarFuel:
                    FuelCarInterface.fuelCarQuestions(i_TheVehicleToAskFor);
                    break;
                case eVehicleType.TruckFuel:
                    FuelTruckInterface.fuelTruckQuestions(i_TheVehicleToAskFor);
                    break;
            }
        }


        private static bool ValidateLicenseNumber(string i_LicenseNumber)
        {
            bool returnFlag = true;

            foreach (char oneChar in i_LicenseNumber)
            {
                if (!Char.IsLetterOrDigit(oneChar))
                {
                    returnFlag = !returnFlag;
                    break;
                }
            }

            return returnFlag;
        }

        private static bool ValidateTypeOfVehicle(int i_TypeOfVehicle)
        {
            bool returnFlag = true;
            int numberOfVehiclesInGarage = Enum.GetValues(typeof(eVehicleType)).Length;
            if (i_TypeOfVehicle < 0 || i_TypeOfVehicle > numberOfVehiclesInGarage)
            {
                returnFlag = !returnFlag;
            }

            return returnFlag;
        }
    }
}
