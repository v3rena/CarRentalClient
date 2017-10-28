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
		MainWindowViewModel ViewModel;

		public MainWindow()
		{
			InitializeComponent();
			ViewModel = new MainWindowViewModel();
			DataContext = ViewModel;
			CarGrid.ItemsSource = ViewModel.Cars;
		}

		private void OnSelectCar(object sender, SelectionChangedEventArgs args)
		{
			DataGrid grid = (DataGrid)sender;
			ViewModel.CurrentCar = (Models.Car)grid.SelectedItem;
		}

		private void OnSelectCustomer(object sender, SelectionChangedEventArgs args)
		{
			ComboBox box = (ComboBox)sender;
			ViewModel.CurrentCustomer = (Models.Customer)box.SelectedItem;
		}

		private void OnSelectDate(object sender, SelectionChangedEventArgs args)
		{
			DatePicker box = (DatePicker)sender;
			ViewModel.ReturnDate = (DateTime)box.SelectedDate;
		}

		private void Refresh()
		{
			ViewModel.Cars=(List<Models.Car>)ViewModel.GetAllCars();
			ViewModel.Customers = (List<Models.Customer>)ViewModel.GetAllCustomers();
			CarGrid.ItemsSource = ViewModel.Cars;
			CustomerList.ItemsSource = ViewModel.Customers;
		}

		private void ReturnCar(object sender, RoutedEventArgs e)
		{
			var car = ViewModel.CurrentCar;
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
				ViewModel.Update(car);
			}
			Refresh();
		}

		private void BookCar(object sender, RoutedEventArgs e)
		{
			var car = ViewModel.CurrentCar;
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
					var customer = ViewModel.CurrentCustomer;
					if (customer == null)
					{
						MessageBox.Show("Please select a customer");
					}
					else
					{
						car.Customer = customer;
						car.CustomerID = customer.ID;
						car.IsAvailable = false;
						car.TimeShouldReturn = ViewModel.ReturnDate;
						ViewModel.Update(car);
					}
				}
			}
			Refresh();
		}
	}
}
