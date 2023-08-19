using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.eNum;

namespace ConsoleUI.Actions
{
    class MotorcycleInterface
    {
        public static void motorcycleQuestions(Vehicle i_TheVehicle)
        {
            int licenseType, EngineVolumeInCC;
            bool flagToHelp = true;
            bool isLicenseTypeOK, isVolumeInCCOK;

            Console.WriteLine("Please enter the license type");
            Console.Write(Motorcycle.ShowLicenseTypes());
            Console.WriteLine();
            isLicenseTypeOK = int.TryParse(Console.ReadLine(), out licenseType);
            StringBuilder airPressureMessage = new StringBuilder();

            while (flagToHelp)
            {
                try
                {
                    if (isLicenseTypeOK)
                    {
                        (i_TheVehicle as Motorcycle).SetLicenseType((eLicenseType)licenseType);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a correct license type from the list:");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(Motorcycle.ShowLicenseTypes());
                isLicenseTypeOK = int.TryParse(Console.ReadLine(), out licenseType);
            }

            Console.WriteLine();

            Console.WriteLine("Please enter the engine CC (normal number e.g 200,300..)");
            isVolumeInCCOK = int.TryParse(Console.ReadLine(), out EngineVolumeInCC);
            while (flagToHelp)
            {
                try
                {
                    if (isVolumeInCCOK)
                    {
                        (i_TheVehicle as Motorcycle).SetEngineVolume(EngineVolumeInCC);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a correct engine volume in CC");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                isVolumeInCCOK = int.TryParse(Console.ReadLine(), out EngineVolumeInCC);
            }
        }
    }
}
