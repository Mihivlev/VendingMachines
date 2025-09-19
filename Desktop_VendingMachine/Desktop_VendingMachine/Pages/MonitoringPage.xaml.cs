using Desktop_VendingMachine.classes;
using System.Linq;
using System.Windows.Controls;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для MonitoringPage.xaml
	/// </summary>
	public partial class MonitoringPage : Page
	{
		public MonitoringPage()
		{
			InitializeComponent();
			DGMonitoring.ItemsSource = StorageClass.machinesEntities.VendingMachines.ToList();
		}

		private void DGMonitoring_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			e.Row.Header = (e.Row.GetIndex()).ToString();
        }
    }
}
