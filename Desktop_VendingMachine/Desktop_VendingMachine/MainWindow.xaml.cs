using System.Windows;
using Desktop_VendingMachine.classes;
using Desktop_VendingMachine.Pages;

namespace Desktop_VendingMachine
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			StorageClass.MainFrame = MainFrame;
			MainFrame.Navigate(new AuthorizationPage());

			//string text = "C:\\prof\\products.json";
			//FileStream file = new FileStream(text, FileMode.OpenOrCreate);
			//List<Products> products = JsonSerializer.Deserialize<List<Products>>(file);
   //         foreach (var item in products)
   //         {
			//	StorageClass.machinesEntities.Products.Add(item);
   //         }
			//StorageClass.machinesEntities.SaveChanges();
        }
	}
}
