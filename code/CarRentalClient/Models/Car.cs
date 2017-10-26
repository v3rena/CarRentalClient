using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalClient.Models
{
	public class Car
	{
		public int ID { get; set; }
		public string Model { get; set; }
		public float Price { get; set; }
		public DateTime? TimeShouldReturn { get; set; }
		public bool IsAvailable { get; set; }
		public int? CustomerID { get; set; }
		public virtual Customer Customer { get; set; }

		public event EventHandler Change;

		protected void OnChange()
		{
			var temp = Change;
			temp?.Invoke(this, EventArgs.Empty);
		}
	}
}
