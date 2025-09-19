using Desktop_VendingMachine.classes;
using System.Linq;
using System.Numerics;
using System.Windows.Controls;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для MainUserPage.xaml
	/// </summary>
	public partial class MainUserPage : Page
	{
		public MainUserPage()
		{
			InitializeComponent();
			double prozent = (double)StorageClass.machinesEntities.VendingMachines.ToList().Where(x => x.status == 2).Count() / StorageClass.machinesEntities.VendingMachines.ToList().Count() * 100;

			effNetwork.Text = "Работающих автоматов - " + (int)prozent + " %" ;
			PBeff.Value = (int)prozent;
		}
	}
}
