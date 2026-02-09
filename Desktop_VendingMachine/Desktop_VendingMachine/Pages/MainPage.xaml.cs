using Desktop_VendingMachine.classes;
using System.Windows;
using System.Windows.Controls;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		Users user;
		public MainPage(Users SelectedUser)
		{
			InitializeComponent();
			user = SelectedUser;

			DataContext = user;
			UserFrame.Navigate(new MainUserPage());
			StorageClass.UserFrame = UserFrame;
		}

		private void profileClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Image image = sender as Image;
			if (profileGrid.Visibility == Visibility.Hidden)
			{
				ProfileUP.Visibility = Visibility.Visible;
				ProfileDown.Visibility = Visibility.Collapsed;
				profileGrid.Visibility = Visibility.Visible;
			}
			else
			{
				ProfileUP.Visibility = Visibility.Collapsed;
				ProfileDown.Visibility = Visibility.Visible;
				profileGrid.Visibility = Visibility.Hidden;
			}
		}

		private void blockAdmin(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (BlockAdminGrid.Visibility == Visibility.Collapsed)
			{
				ABDown.Visibility = Visibility.Collapsed;
				ABUp.Visibility = Visibility.Visible;
				BlockAdminGrid.Visibility = Visibility.Visible;
			}
			else
			{
				ABDown.Visibility = Visibility.Visible;
				ABUp.Visibility = Visibility.Collapsed;
				BlockAdminGrid.Visibility = Visibility.Collapsed;
			}
		}

		private void ToVendingMachines(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new VendingMachinesPage());
		}

		private void ToMain(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new MainUserPage());
		}

		private void ToMonitor(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new MonitoringPage());
        }
    }
}
