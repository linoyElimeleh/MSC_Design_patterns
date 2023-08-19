using GarageLogic;
using GarageLogic.Exception;
using System;

namespace ConsoleUI.Actions
{
    class ElectricInterface
    {
        public static void chargeACar(Garage i_TheGarage, int i_TheNumberOfTimeMenuCalled)
        {
            Console.Clear();
            Console.WriteLine("Please enter your license number");
            string licenseNumber = Console.ReadLine();
            bool flagToHelp = true;
            Vehicle theVehicleToString;
            string messageToUser = "";
            float amoutToCharge;
            bool isAmoutToChargeOK;

            while (flagToHelp && !(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                if (i_TheGarage.IsVehicleInGarage(licenseNumber) && (i_TheGarage.GetVehicle(licenseNumber).GetEnergyType() is Electric))
                {
                    Console.WriteLine(string.Format("alright, the vehicle is in the garage, and can be charged{0}please enter the amount to charge.", Environment.NewLine));
                    isAmoutToChargeOK = float.TryParse(Console.ReadLine(), out amoutToCharge);
                    while (flagToHelp)
                    {
                        if (isAmoutToChargeOK)
                        {
                            try
                            {
                                theVehicleToString = i_TheGarage.GetVehicle(licenseNumber);
                                (theVehicleToString.GetEnergyType() as Electric).ChargeBattery(amoutToCharge);
                                theVehicleToString.SetPercentagesOfEnergyRemaining((theVehicleToString.GetEnergyType() as Electric).ElectricPercentage());
                                messageToUser = "The Battery as been charged.";
                                break;
                            }
                            catch (ValueOutOfRangeException ex)
                            {
                                messageToUser = ex.Message;
                                messageToUser += "Please enter an in-range number.";
                            }
                        }
                        else
                        {
                            messageToUser = "invalid input, please enter a correct form decimal number.";
                        }

                        Console.WriteLine(messageToUser);
                        isAmoutToChargeOK = float.TryParse(Console.ReadLine(), out amoutToCharge);
                    }

                    break;
                }
                else
                {
                    if (!(i_TheGarage.GetVehicle(licenseNumber).GetEnergyType() is Electric) && i_TheGarage.IsVehicleInGarage(licenseNumber))
                    {
                        Console.WriteLine("The vehicle you entered is in the garage but cannot be charged, because it isn't Electric type.");
                        Console.WriteLine("Please enter an electric license number in order to charge the vehicle");
                    }
                    else
                    {
                        Console.WriteLine("The license number you entered isn't valid, please try again");
                    }

                    UserInterface.returnToMainMenuFromInside(i_TheGarage, ref i_TheNumberOfTimeMenuCalled, out licenseNumber);
                }
            }

            if (!(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                Console.WriteLine(messageToUser);
            }
        }

        public static void electricQuestions(Vehicle i_TheVehicle)
        {
            bool flagToHelp = true;
            bool isCurrentChargeOk;
            float currentChargeLevel;

            Console.WriteLine("Please enter the current charge of the vehicle");
            isCurrentChargeOk = float.TryParse(Console.ReadLine(), out currentChargeLevel);
            while (flagToHelp)
            {
                if (isCurrentChargeOk)
                {
                    try
                    {
                        (i_TheVehicle.GetEnergyType() as Electric).SetHoursLeftInBattery(currentChargeLevel);
                        i_TheVehicle.SetPercentagesOfEnergyRemaining(Vehicle.ReimaingEnergyPercentage(currentChargeLevel, (i_TheVehicle.GetEnergyType() as Electric).GetMaxHoursInBattery()));
                        break;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a correct format of charge level");
                }

                isCurrentChargeOk = float.TryParse(Console.ReadLine(), out currentChargeLevel);
            }
        }
    }
}
