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
		}
		private void OnSelectCar(object sender, SelectionChangedEventArgs args)
		{
			DataGrid grid = (DataGrid)sender;
			Models.Car currCar = (Models.Car)grid.SelectedItem;
			MWVM.CurrentCar = currCar;
		}

		private void OnSelectCustomer(object sender, SelectionChangedEventArgs args)
		{
			ComboBox box = (ComboBox)sender;
			Models.Customer currCus = (Models.Customer)box.SelectedItem;
			MWVM.CurrentCustomer = currCus;
		}
	}
}
