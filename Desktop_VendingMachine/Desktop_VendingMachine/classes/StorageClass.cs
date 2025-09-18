using System.Windows.Controls;

namespace Desktop_VendingMachine.classes
{
	internal class StorageClass
	{
		public static DB_VendingMachinesEntities machinesEntities = new DB_VendingMachinesEntities();
		public static Frame MainFrame { get; set; }
		public static Frame UserFrame { get; set; }
	}
}
