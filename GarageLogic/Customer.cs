using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Customer
    {
        private string m_CustomerName { get; set; }

        private string m_CustomerPhone { get; set; }

        private Vehicle m_CustomerVehicle { get; set; }

        public Customer(string i_CustomerName, string i_CustomerPhoneNumber, Vehicle i_OneVehicle)
        {
            this.m_CustomerName = i_CustomerName;
            this.m_CustomerPhone = i_CustomerPhoneNumber;
            this.m_CustomerVehicle = i_OneVehicle;
        }

        public override string ToString()
        {
            StringBuilder infoOfCustomer = new StringBuilder();
            infoOfCustomer.AppendLine(base.ToString());
            infoOfCustomer.AppendLine("--------------------");
            infoOfCustomer.AppendLine("Customer deatils:");
            infoOfCustomer.AppendLine("Customer name : " + m_CustomerName.ToString());
            infoOfCustomer.AppendLine("Customer phone : " + m_CustomerPhone.ToString());
            return infoOfCustomer.ToString();
        }
    }
}
