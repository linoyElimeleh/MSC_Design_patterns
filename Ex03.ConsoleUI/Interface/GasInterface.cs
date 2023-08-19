using GarageLogic;
using System;
using static GarageLogic.eNum;

namespace ConsoleUI.Actions
{
    class GasInterface
    {
        public static void gasAVehicle(Garage i_TheGarage)
        {
            Console.Clear();
            Console.WriteLine("Please enter your license number");
            string licenseNumber = Console.ReadLine();
            Vehicle i_TheVehicle;
            string messageToUser = "";
            int WhichFuelType, count = 1;
            bool isAmoutToFuel, isFuelTypeOk, didEverythingFlag = false, flagToHelp = true;
            float amoutToFuel;

            while (flagToHelp && !(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                if (i_TheGarage.IsVehicleInGarage(licenseNumber) && (i_TheGarage.GetVehicle(licenseNumber).GetEnergyType() is Fuel))
                {
                    i_TheVehicle = i_TheGarage.GetVehicle(licenseNumber);
                    if (count == 1)
                    {
                        Console.WriteLine(string.Format("alright, the vehicle is in the garage, and can be fueled{0}", Environment.NewLine));
                        count++;
                    }

                    Console.WriteLine(string.Format("Please enter the fuel type:{0}", Environment.NewLine));
                    Console.WriteLine(Fuel.ShowFuelTypes());
                    isFuelTypeOk = int.TryParse(Console.ReadLine(), out WhichFuelType);
                    if (isFuelTypeOk && Fuel.IsFuelTypeOk(WhichFuelType))
                    {
                        Console.WriteLine(string.Format("Please enter amout to fuel:{0}", Environment.NewLine));
                        isAmoutToFuel = float.TryParse(Console.ReadLine(), out amoutToFuel);
                        if (isAmoutToFuel)
                        {
                            try
                            {
                                (i_TheVehicle.GetEnergyType() as Fuel).FillTheFuelTank(amoutToFuel, (eFuelTypes)WhichFuelType);
                                i_TheVehicle.SetPercentagesOfEnergyRemaining((i_TheVehicle.GetEnergyType() as Fuel).FuelPercentage());
                                messageToUser = "The vehicle has been fueled";
                                didEverythingFlag = !didEverythingFlag;
                                break;
                            }
                            catch (Exception ex)
                            {
                                messageToUser = ex.Message;
                            }
                        }
                        else
                        {
                            messageToUser = string.Format("Invalid input, please enter a correct decimal number:{0}", Environment.NewLine);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a correct type, according to the list:");
                    }
                }
                else
                {
                    if (!(i_TheGarage.GetVehicle(licenseNumber).GetEnergyType() is Fuel) && i_TheGarage.IsVehicleInGarage(licenseNumber))
                    {
                        Console.WriteLine("The vehicle you entered is in the garage but cannot be fueled, because it isn't fuel type.");
                        Console.WriteLine("Please enter an fuel-based license number vehicle in order to charge the vehicle");
                        Console.WriteLine("Or enter 'M' to return to the main menu");
                    }
                    else
                    {
                        Console.WriteLine("The license number you entered isn't valid, please try again");
                        Console.WriteLine("Or enter 'M' to return to the main menu");
                    }

                    licenseNumber = Console.ReadLine();
                }

                if (didEverythingFlag || licenseNumber.Equals("m") || licenseNumber.Equals("M"))
                {
                    break;
                }

                Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, messageToUser));
            }

            if (!(licenseNumber.Equals("M") || licenseNumber.Equals("m")))
            {
                Console.WriteLine(messageToUser);
            }
        }
    }
}
