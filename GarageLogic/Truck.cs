using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingToxicMaterials;
        private float m_VolumeOfCargo;

        internal Truck(string i_LicenseNumber, int i_NumOfWheels, float i_MaxAirPressure, object i_EnergyType) :
                              base(i_LicenseNumber, i_NumOfWheels, i_MaxAirPressure, i_EnergyType)
        {

        }

        public void SetVolumeOfCargo(float i_NewVolumeOfCargo)
        {
            if (i_NewVolumeOfCargo > 0)
            {
                m_VolumeOfCargo = i_NewVolumeOfCargo;
            }
            else
            {
                throw new ArgumentException("Volume of cargo is not valid.");
            }
        }

        public void SetIsCarryingToxicMaterials(bool i_NewModeForToxicMaterials)
        {
            m_IsCarryingToxicMaterials = i_NewModeForToxicMaterials;
        }

        public override string ToString()
        {
            StringBuilder infoOfTruck = new StringBuilder();
            infoOfTruck.AppendLine(base.ToString());
            infoOfTruck.AppendLine("--------------------");
            infoOfTruck.AppendLine("Type of vehicle: Truck");
            infoOfTruck.AppendLine("Truck is carrying toxic materials?: " + m_IsCarryingToxicMaterials);
            infoOfTruck.AppendLine("The volume of the cargo is: " + m_VolumeOfCargo);
            
            return infoOfTruck.ToString();
        }
    }
}
