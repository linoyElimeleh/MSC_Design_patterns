using GarageLogic.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.eNum;

namespace GarageLogic
{
    public class Garage
    {
        private List<Vehicle> m_ListOfAllVehicle;
        private Dictionary<string, eNum.eVehicleStatus> m_DictOfStatusByLicense;

        public Garage()
        {
            m_ListOfAllVehicle = new List<Vehicle>();
            m_DictOfStatusByLicense = new Dictionary<string, eVehicleStatus>();
        }

        public void EnterANewVehicleToTheGarage(Vehicle i_VehicleToAdd)
        {
            m_ListOfAllVehicle.Add(i_VehicleToAdd);
            m_DictOfStatusByLicense[i_VehicleToAdd.GetLicenseNumber()] = eVehicleStatus.inRepair;
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool returnFlag = true;
            if (!m_DictOfStatusByLicense.ContainsKey(i_LicenseNumber))
            {
                returnFlag = !returnFlag;
            }

            return returnFlag;
        }

        public List<Vehicle> DisplayCarStatus(eNum.eVehicleStatus i_StatusOfDesiredCar)
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();
            foreach (Vehicle oneVehicle in m_ListOfAllVehicle)
            {
                if (m_DictOfStatusByLicense[oneVehicle.GetLicenseNumber()].Equals(i_StatusOfDesiredCar))
                {
                    listOfVehicles.Add(oneVehicle);
                }
            }

            return listOfVehicles;
        }

        public static string ShowVehicleStatus()
        {
            StringBuilder vehicleTypes = new StringBuilder();
            int counter = 1;
            foreach (eVehicleStatus type in Enum.GetValues(typeof(eVehicleStatus)))
            {
                if (Enum.GetValues(typeof(eVehicleStatus)).Length == counter)
                {
                    vehicleTypes.Append(string.Format("[{0}] {1}", (int)type, type.ToString()));
                }
                else
                {
                    counter++;
                    vehicleTypes.Append(string.Format("[{0}] {1}{2}", (int)type, type.ToString(), Environment.NewLine));
                }
            }

            return vehicleTypes.ToString();
        }

        public void ChangeCarStatus(string i_LicenseNumber, eNum.eVehicleStatus i_NewDesiredStatus)
        {
            if (IsVehicleInGarage(i_LicenseNumber) && m_DictOfStatusByLicense[i_LicenseNumber] != i_NewDesiredStatus)
            {
                m_DictOfStatusByLicense[i_LicenseNumber] = i_NewDesiredStatus;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void IsRangeOfVehicleStatus(int i_TheNumberOfStatus, out eVehicleStatus o_TheNewStatusToReturn)
        {
            if (Enum.GetValues(typeof(eVehicleStatus)).Length >= i_TheNumberOfStatus && i_TheNumberOfStatus > 0)
            {
                o_TheNewStatusToReturn = (eVehicleStatus)i_TheNumberOfStatus;
            }
            else
            {
                throw new ValueOutOfRangeException(Enum.GetValues(typeof(eVehicleStatus)).Length, 1);
            }
        }

        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            Vehicle returnVehicle = m_ListOfAllVehicle[0];
            foreach (Vehicle oneVehicle in m_ListOfAllVehicle)
            {
                if (oneVehicle.GetLicenseNumber().Equals(i_LicenseNumber))
                {
                    returnVehicle = oneVehicle;
                    break;
                }
            }

            return returnVehicle;
        }
    }
}
