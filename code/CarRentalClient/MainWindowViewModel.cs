using CarRentalClient.Models;
using CarRentalClient.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarRentalClient
{
	public class MainWindowViewModel
	{
		private readonly ICarRepository carRepo = new CarRepository();
		private readonly ICustomerRepository customerRepo = new CustomerRepository();

		public MainWindowViewModel()
		{
			Cars = (List<Car>)carRepo.GetAll();
			Customers = (List<Customer>)customerRepo.GetAll();
			ReturnDate = DateTime.Now;
			CurrentCustomer = Customers.FirstOrDefault();
		}

		public void Update(Car car)
		{
			carRepo.Update(car);
		}

		public IEnumerable<Car> GetAllCars()
		{
			return carRepo.GetAll();
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return customerRepo.GetAll();
		}

		private IList<Car> _cars;
		public IList<Car> Cars
		{
			get { return _cars; }
			set { _cars = value; }
		}

		private DateTime _returnDate;
		public DateTime ReturnDate
		{
			get { return _returnDate; }
			set { _returnDate = value; }
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
			}
		}

		private Customer _currentCustomer;
		public Customer CurrentCustomer
		{
			get { return _currentCustomer; }
			set
			{
				_currentCustomer = value;

				if (Equals(_currentCustomer, value)) return;
				_currentCustomer = value as Customer;
			}
		}
	}
}
