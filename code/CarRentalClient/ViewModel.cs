using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalClient
{
	/// <summary>
	/// Abstract class for all ViewModels to implement OnPropertyChanged
	/// </summary>
	public abstract class ViewModel : DependencyObject, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Invokes PropertyChangedEvent on the given property
		/// </summary>
		/// <param name="prop"></param>
		protected void OnPropertyChanged(string prop)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
