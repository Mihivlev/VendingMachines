using Desktop_VendingMachine.classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для VendingMachinesPage.xaml
	/// </summary>
	public partial class VendingMachinesPage : Page
	{
		int pageCount = 1;
		public VendingMachinesPage()
		{
			InitializeComponent();
			LoadData();
		}

		private void LoadData()
		{
			DGVendingMachines.ItemsSource = StorageClass.machinesEntities.VendingMachines.ToList();
			int count = StorageClass.machinesEntities.VendingMachines.ToList().Count();
			TBCount.Text = "Всего найдено " + count.ToString() + " штук";
			TBSecondCount.Text = "Записи с 1 до " + count.ToString() + " из " + count.ToString() + " записей";
		}

		private void AddVB(object sender, RoutedEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new VMModelPage(null));
		}

		private void Edit(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new VMModelPage(((Image)sender).DataContext as VendingMachines));
		}

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
				StorageClass.machinesEntities.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
			LoadData();
		}

		private void Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Удалить торговый автомат","Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
			if (result == MessageBoxResult.OK) 
			{
				StorageClass.machinesEntities.VendingMachines.Remove(((Image)sender).DataContext as VendingMachines);
				StorageClass.machinesEntities.SaveChanges();
				MessageBox.Show("Торговый автомат удален");
				LoadData();
			}
        }

		private void pagePrev(object sender, RoutedEventArgs e)
		{
			if (pageCount > 1)
				pageCount--;
			TBPage.Text = pageCount.ToString();
		}

		private void pageNext(object sender, RoutedEventArgs e)
		{
			pageCount++;
			TBPage.Text = pageCount.ToString();
		}
	}
}
