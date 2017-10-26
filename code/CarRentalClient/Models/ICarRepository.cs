using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalClient.Models
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetAll();
		Car Get(int id);
		bool Update(Car car);
	}
}
