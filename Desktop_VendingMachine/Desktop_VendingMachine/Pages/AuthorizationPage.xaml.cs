using Desktop_VendingMachine.classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для AuthorizationPage.xaml
	/// </summary>
	public partial class AuthorizationPage : Page
	{
		public AuthorizationPage()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//Users user = StorageClass.machinesEntities.Users.FirstOrDefault(x => x.email == TBEmail.Text && TBPassword.Password == x.password);
			Users user = StorageClass.machinesEntities.Users.FirstOrDefault(x => x.email == "gleb_1990@example.com");
			if (user != null)
				StorageClass.MainFrame.Navigate(new MainPage(user));
			else
				MessageBox.Show("Пользователь не найден");
        }
    }
}
