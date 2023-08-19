using GarageLogic.Exception;
using System;
using System.Text;

namespace GarageLogic
{
    public class Electric
    {
        private readonly float r_MaxHoursInBattery;
        private float m_HoursLeftInBattery;

        public Electric(float i_MaxHours)
        {
            r_MaxHoursInBattery = i_MaxHours;
            m_HoursLeftInBattery = 0f;
        }

        public float GetMaxHoursInBattery()
        {
            return r_MaxHoursInBattery;
        }

        public void SetHoursLeftInBattery(float i_HoursLeft)
        {
            if (i_HoursLeft >= 0 && i_HoursLeft <= r_MaxHoursInBattery)
            {
                m_HoursLeftInBattery = i_HoursLeft;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxHoursInBattery, 0f);
            }
        }

        public bool ChargeBattery(float i_HoursToAdd)
        {
            bool charged = false;

            if (i_HoursToAdd + m_HoursLeftInBattery <= r_MaxHoursInBattery)
            {
                SetHoursLeftInBattery(i_HoursToAdd);
                charged = true;
            }
            else
            {
                throw new ValueOutOfRangeException((r_MaxHoursInBattery - m_HoursLeftInBattery), 0f);
            }

            return charged;
        }

        public float ElectricPercentage()
        {
            return (m_HoursLeftInBattery / r_MaxHoursInBattery) * 100;
        }

        public override string ToString()
        {
            StringBuilder infoOfElectric = new StringBuilder();
            infoOfElectric.AppendLine(base.ToString());
            infoOfElectric.AppendLine(string.Format(
                "The battery has {0} hours left out of {1} hours.",m_HoursLeftInBattery, r_MaxHoursInBattery));
            
            return infoOfElectric.ToString();
        }
    }
}
