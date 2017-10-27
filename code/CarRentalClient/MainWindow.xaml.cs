using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentalClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainWindowViewModel MWVM;

		public MainWindow()
		{
			InitializeComponent();
			MWVM = new MainWindowViewModel();
			DataContext = MWVM;
			CarGrid.ItemsSource = MWVM.Cars;
		}

		private void OnSelectCar(object sender, SelectionChangedEventArgs args)
		{
			DataGrid grid = (DataGrid)sender;
			MWVM.CurrentCar = (Models.Car)grid.SelectedItem;
		}

		private void OnSelectCustomer(object sender, SelectionChangedEventArgs args)
		{
			ComboBox box = (ComboBox)sender;
			MWVM.CurrentCustomer = (Models.Customer)box.SelectedItem;
		}

		private void OnSelectDate(object sender, SelectionChangedEventArgs args)
		{
			DatePicker box = (DatePicker)sender;
			MWVM.ReturnDate = (DateTime)box.SelectedDate;
		}

		private void Refresh()
		{
			MWVM.Cars=(List<Models.Car>)MWVM.GetAllCars();
			MWVM.Customers = (List<Models.Customer>)MWVM.GetAllCustomers();
			CarGrid.ItemsSource = MWVM.Cars;
			CustomerList.ItemsSource = MWVM.Customers;
		}

		private void ReturnACar(object sender, RoutedEventArgs e)
		{
			var car = MWVM.CurrentCar;
			if (car==null)
			{
				MessageBox.Show("Please select a car");
			}
			else
			{
				car.Customer = null;
				car.CustomerID = null;
				car.IsAvailable = true;
				car.TimeShouldReturn = null;
				MWVM.Update(car);
			}
			Refresh();
		}

		private void BookACar(object sender, RoutedEventArgs e)
		{
			var car = MWVM.CurrentCar;
			if (car==null)
			{
				MessageBox.Show("Please select a car");
			}
			else
			{
				if (car.Customer!=null)
				{
					MessageBox.Show("Car already booked. Please select another car.");
				}
				else
				{
					var customer = MWVM.CurrentCustomer;
					if (customer == null)
					{
						MessageBox.Show("Please select a customer");
					}
					else
					{
						car.Customer = customer;
						car.CustomerID = customer.ID;
						car.IsAvailable = false;
						car.TimeShouldReturn = MWVM.ReturnDate;
						MWVM.Update(car);
					}
				}
			}
			Refresh();
		}
	}
}
