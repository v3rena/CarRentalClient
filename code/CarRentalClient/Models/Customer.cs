using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalClient.Models
{
	public class Customer
	{
		public  Customer(int ID, string name, string lastname)
		{
			this.ID = ID;
			this.FirstName = name;
			this.LastName = lastname;
		}
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
