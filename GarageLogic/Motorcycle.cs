using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.eNum;

namespace GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeInCC;

        public Motorcycle(string i_LicenseNumber, int i_NumOfWheels, float i_MaxAirPressure, object i_EnergyType) :
                              base(i_LicenseNumber, i_NumOfWheels, i_MaxAirPressure, i_EnergyType)
        {

        }

        public void SetLicenseType(eLicenseType i_NewLicenseType)
        {
            if (Enum.IsDefined(typeof(eLicenseType), i_NewLicenseType))
            {
                m_LicenseType = i_NewLicenseType;
            }
            else
            {
                throw new ArgumentException("License type is invalid.");
            }
        }

        public void SetEngineVolume(int i_NewEngineVolume)
        {
            if (i_NewEngineVolume > 0)
            {
                m_EngineVolumeInCC = i_NewEngineVolume;
            }
            else
            {
                throw new ArgumentException("Invalid input, please enter a correct engine volume in CC.");
            }
        }

        public static string ShowLicenseTypes()
        {
            StringBuilder strLicenseTypes = new StringBuilder();
            foreach (eLicenseType licenseType in Enum.GetValues(typeof(eLicenseType)))
            {
                strLicenseTypes.Append(string.Format("[{0}] {1}{2}", (int)licenseType, licenseType.ToString(), Environment.NewLine));
            }

            return strLicenseTypes.ToString();
        }

        public override string ToString()
        {
            StringBuilder infoOfMotorcycle = new StringBuilder();
            infoOfMotorcycle.AppendLine(base.ToString());
            infoOfMotorcycle.AppendLine("--------------------");
            infoOfMotorcycle.AppendLine("Type of vehicle : Motorcycle");
            infoOfMotorcycle.AppendLine("Licence Type " + m_LicenseType.ToString());
            infoOfMotorcycle.AppendLine("The volume of the engine is: " + m_EngineVolumeInCC);
            
            return infoOfMotorcycle.ToString();
        }
    }
}
