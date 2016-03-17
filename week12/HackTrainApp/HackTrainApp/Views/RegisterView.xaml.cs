using System;
using HackTrain.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HackTrain.ViewModels;
using HackTrain.Views;
using HackTrainApp.Views;


namespace HackTrainApp
{
	public partial class RegisterView : IRegisterView
	{
		private readonly List<Control> _requiredInputs;
		private readonly SolidColorBrush _defaultBackground;
		private readonly SolidColorBrush _errorBackground;
		private readonly RegisterViewModel _viewModel;

		public RegisterView()
		{
			InitializeComponent();

			_requiredInputs = new List<Control>
			{
				InputUsername,
				InputEmail,
				InputPassword,
				InputRepeatPass,
				InputFirstName,
				InputLastName,
			};			

			_defaultBackground = (SolidColorBrush) InputUsername.Background;
			_errorBackground = new SolidColorBrush(Color.FromRgb(190, 32, 28));
			_viewModel = new RegisterViewModel(this);
		}

		private void RegisterButtonClick(object sender, RoutedEventArgs e)
		{
			ResetInputsColors();

				var emptyInputs = GetEmptyInputs().ToList();

			if (emptyInputs.Any())
			{
				foreach (var input in emptyInputs)
				{
					input.Background = _errorBackground;
				}
			}
			else
			{
				if (!CheckPasswordMatch())
				{
					InputRepeatPass.Background = _errorBackground;
					return;
				}

				if (!ValidateEmail(InputEmail.Text))
				{
					InputEmail.Background = _errorBackground;
					return;
				}

				var newUser = CreateUserFromInputs();
				RegisterUser(newUser);
			}
		}

		private void RegisterWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var errors = e.Result as RegisterErrors?;

			//This shouldn't execute
			if (errors == null)
			{
				MessageBox.Show("Register Error Null");
				return;
			}

			//No errors
			if (errors == RegisterErrors.None)
			{
				CloseRegistration();
			}

			//Database error
			if ((errors & RegisterErrors.DataBaseError) != 0)
			{
				MessageBox.Show("Registration Database Error");
			}

			//Username taken
			if((errors.Value & RegisterErrors.UsernameTaken) != 0)
			{
				InputUsername.Background = _errorBackground;
			}

			//Email taken
			if((errors.Value & RegisterErrors.EmailTaken) != 0)
			{
				InputEmail.Background = _errorBackground;
			}
		}

		private void ResetInputsColors()
		{
			foreach (var textBox in _requiredInputs)
			{
				textBox.Background = _defaultBackground;
			}
		}

		private void CloseRegistration()
		{
			var view = new StartUpView();
			view.Show();
			this.Close();
		}

		private bool CheckPasswordMatch()
		{
			return InputPassword.Password == InputRepeatPass.Password;
		}

		private IEnumerable<Control> GetEmptyInputs()
		{
			return _requiredInputs.Where(control =>
			{
				var textBox = control as TextBox;
				if (textBox != null)
				{
					return string.IsNullOrWhiteSpace(textBox.Text);
				}

				var passBox = control as PasswordBox;
				if (passBox != null)
				{
					return string.IsNullOrWhiteSpace(passBox.Password);
				}

				return false;
			});
		}

		private static bool ValidateEmail(string email)
		{
			//Magic ... :)

			return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
		}

		private User CreateUserFromInputs()
		{
			return new User
			{
				Username = InputUsername.Text,
				Email = InputEmail.Text,
				PassHash = SecurePasswordHasher.Hash(InputPassword.Password),
				FirstName = InputFirstName.Text,
				LastName = InputLastName.Text,
				Address = InputAddress.Text,
				ZipCode = InputZipCode.Text,
			};
		}

		private void RegisterUser(User user)
		{
			var registerWorker = new BackgroundWorker();
			registerWorker.DoWork += (obj, doEvent) => { doEvent.Result = _userAccess.Register(user); };
			registerWorker.RunWorkerCompleted += RegisterWorkerCompleted;
			registerWorker.RunWorkerAsync();
		}

	}
}
