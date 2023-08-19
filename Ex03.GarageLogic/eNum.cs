using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class eNum
    {
        public enum eVehicleStatus
        {
            inRepair = 1,
            Repaired,
            Paid
        }

        public enum eVehicleType
        {
            MotorcycleFuel = 1,
            MotorcycleElectric,
            CarFuel,
            CarElectric,
            TruckFuel
        }

        public enum eColors
        {
            Red = 1,
            White,
            Black,
            Yellow
        }

        public enum eDoors
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public enum eLicenseType
        {
            A1 = 1,
            B1,
            A2,
            AA
        }

        public enum eFuelTypes
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }
    }
}
