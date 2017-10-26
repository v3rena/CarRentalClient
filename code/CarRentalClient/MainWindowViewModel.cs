using CarRentalClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarRentalClient
{
	public class MainWindowViewModel : ViewModel
	{
		static readonly ICarRepository carRepo = new CarRepository();
		static readonly ICustomerRepository customerRepo = new CustomerRepository();


		public MainWindowViewModel()
		{
			Cars = (List<Car>)carRepo.GetAll();
			Customers = (List<Customer>)customerRepo.GetAll();

			CurrentCar = Cars.FirstOrDefault();
			CurrentCar.Change += CurrentCarChanged;
		}

		private IList<Car> _cars;
		public IList<Car> Cars
		{
			get { return _cars; }
			set { _cars = value; }
		}

		private IList<Customer> _customers;
		public IList<Customer> Customers
		{
			get { return _customers; }
			set { _customers = value; }
		}

		private Car _currentCar;
		public Car CurrentCar
		{
			get { return _currentCar; }
			set {
				_currentCar = value;

				if (Equals(_currentCar, value)) return;
				_currentCar = value as Car;
				OnPropertyChanged("CurrentCar");
			}
		}

		private void CurrentCarChanged(object sender, EventArgs e)
		{
			OnPropertyChanged("CurrentCar");
		}

		private ICommand _bookCar;
		public ICommand BookCar
		{
			get
			{
				return _bookCar ?? (_bookCar = new SimpleCommand(
						   () => carRepo.Update(CurrentCar),
						   () => true));
			}
		}

		private ICommand _returnCar;
		public ICommand ReturnCar
		{
			get
			{
				return _returnCar ?? (_returnCar = new SimpleCommand(
						   () => carRepo.Update(CurrentCar),
						   () => true));
			}
		}

		public event EventHandler Change;

		protected void OnChange()
		{
			var temp = Change;
			temp?.Invoke(this, EventArgs.Empty);
		}
	}
}
