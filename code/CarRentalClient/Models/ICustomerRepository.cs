using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalClient.Models
{
	interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();
	}
}
