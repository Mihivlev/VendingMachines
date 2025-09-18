using Desktop_VendingMachine.classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
				image.Source = new BitmapImage(new Uri("/Resources/icons/black/angle-up.png", UriKind.Relative));
				profileGrid.Visibility = Visibility.Visible;
			}
			else
			{
				image.Source = new BitmapImage(new Uri("/Resources/icons/black/angle-down.png", UriKind.Relative));
				profileGrid.Visibility = Visibility.Hidden;
			}
		}

		private void blockAdmin(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (BlockAdminGrid.Visibility == Visibility.Hidden)
			{
				ImgAdminBlock.Source = new BitmapImage(new Uri("/Resources/icons/white/angle-up.png", UriKind.Relative));
				BlockAdminGrid.Visibility = Visibility.Visible;
			}
			else
			{
				ImgAdminBlock.Source = new BitmapImage(new Uri("/Resources/icons/white/angle-down.png", UriKind.Relative));
				BlockAdminGrid.Visibility = Visibility.Hidden;
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
