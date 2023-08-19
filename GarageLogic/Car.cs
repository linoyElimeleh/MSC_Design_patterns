using GarageLogic.Exception;
using System;
using System.Text;
using static GarageLogic.eNum;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        private eColors m_Color;
        private eDoors m_Doors;

        public eColors CarColor { get; set; }
        public eDoors NumOfDoors { get; set; }

        internal Car(string i_LicenseNumber, int i_NumOfWheels, float i_MaxAirPressure, object i_EnergyType) :
                                                     base(i_LicenseNumber, i_NumOfWheels, i_MaxAirPressure, i_EnergyType)
        {
        }

        public override string ToString()
        {
            StringBuilder infoOfCar = new StringBuilder();
            infoOfCar.AppendLine(base.ToString());
            infoOfCar.AppendLine("--------------------");
            infoOfCar.AppendLine("Type of vehicle : Car");
            infoOfCar.AppendLine("Color of the car : " + m_Color.ToString());
            infoOfCar.AppendLine("Number of doors : " + m_Doors.ToString());
            return infoOfCar.ToString();
        }

        public void SetColor(eColors i_eColors)
        {
            if (Enum.IsDefined(typeof(eColors), i_eColors))
            {
                m_Color = i_eColors;
            }
            else
            {
                throw new ValueOutOfRangeException((float)Enum.GetValues(typeof(eColors)).Length, 1f);
            }
        }

        public void SetDoors(eDoors i_ValueDoora)
        {
            if (Enum.IsDefined(typeof(eDoors), i_ValueDoora))
            {
                this.m_Doors = i_ValueDoora;
            }
            else
            {
                throw new ValueOutOfRangeException((float)Enum.GetValues(typeof(eDoors)).Length, 1f);
            }

        }

        public static string ShowColorsOptions()
        {
            StringBuilder colors = new StringBuilder();

            foreach (eColors color in Enum.GetValues(typeof(eColors)))
            {
                colors.Append(string.Format("[{0}] {1}{2}", (int)color, color.ToString(), Environment.NewLine));
            }

            return colors.ToString();
        }

        public static string ShowNumberOfDoors()
        {
            StringBuilder strNumberOfDoors = new StringBuilder();

            foreach (eDoors doors in Enum.GetValues(typeof(eDoors)))
            {
                strNumberOfDoors.Append(string.Format("[{0}] {1}{2}", (int)doors, doors.ToString(), Environment.NewLine));
            }

            return strNumberOfDoors.ToString();
        }

    }
}
