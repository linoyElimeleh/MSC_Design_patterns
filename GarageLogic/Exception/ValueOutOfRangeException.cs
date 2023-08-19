using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic.Exception
{
    public class ValueOutOfRangeException : SystemException
    {
        public float m_MaxValue { get; }
        public float m_MinValue { get; }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("Value is not in the range from {0} to {1}", i_MinValue, i_MaxValue))
        { }

        public float GetMaxValue()
        {
            return m_MaxValue;
        }
        public float GetMinValue()
        {
            return m_MinValue;
        }
    }
}
