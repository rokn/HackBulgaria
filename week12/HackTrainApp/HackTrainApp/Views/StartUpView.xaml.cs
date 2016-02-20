using System.Windows;

namespace HackTrainApp.Views
{
	public partial class StartUpView
	{
		public StartUpView()
		{
			InitializeComponent();
		}

		private void LoginButtonClick(object sender, RoutedEventArgs e)
		{
			var loginView = new LoginView();
			loginView.Show();
			Close();
		}

		private void RegisterButtonClick(object sender, RoutedEventArgs e)
		{
			RegisterView registerView = new RegisterView();
			registerView.Show();
			Close();
		}
	}
}
