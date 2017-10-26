using System;
using System.Windows.Input;

namespace CarRentalClient
{
	public class SimpleCommand : ICommand
	{
		public interface ICommandViewModel : ICommand
		{
			void OnCanExecuteChanged();
		}

		private Action _execute;
		private Func<bool> _canExecute;

		public SimpleCommand(Action execute, Func<bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}
		public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
			{
				return _canExecute();
			}
			return CanExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute();
		}

		public event EventHandler CanExecuteChanged;

		public void OnCanExecuteChanged()
		{
			var temp = CanExecuteChanged;
			temp?.Invoke(this, EventArgs.Empty);
		}
		public class CommandViewModel : ViewModel, ICommandViewModel
		{
			/// <summary>
			/// Checks if command can be executed.
			/// </summary>
			/// <param name="parameter"></param>
			/// <returns></returns>
			public virtual bool CanExecute(object parameter)
			{
				return true;
			}

			public event EventHandler CanExecuteChanged;

			public void OnCanExecuteChanged()
			{
				var temp = CanExecuteChanged;
				temp?.Invoke(this, EventArgs.Empty);
			}

			public virtual void Execute(object parameter)
			{

			}
		}

		public class SimpleCommandViewModel : CommandViewModel
		{
			/// <summary>
			/// Provides a simple CommandViewModel.
			/// </summary>
			/// <param name="execute"></param>
			/// <param name="canExecute"></param>
			public SimpleCommandViewModel(Action execute, Func<bool> canExecute = null)
			{
				if (execute == null) throw new ArgumentNullException("execute");
				_execute = execute;
				_canExecute = canExecute;
			}

			private Action _execute;
			private Func<bool> _canExecute;

			public override bool CanExecute(object parameter)
			{
				if (_canExecute != null)
				{
					return _canExecute();
				}
				return base.CanExecute(parameter);
			}

			public override void Execute(object parameter)
			{
				_execute();
			}
		}
	}
}