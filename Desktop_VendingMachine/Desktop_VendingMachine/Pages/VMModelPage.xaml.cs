using Desktop_VendingMachine.classes;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для VMModelPage.xaml
	/// </summary>
	public partial class VMModelPage : Page
	{
		bool isNew = true;
		VendingMachines machine = new VendingMachines();
		public VMModelPage(VendingMachines selectedMachine)
		{
			InitializeComponent();
			if (selectedMachine != null)
			{
				machine = selectedMachine;
				TBSave.Text = "Сохранить";
				TBTitle.Text = machine.name + ", " + machine.place;
				CBModel.ItemsSource = StorageClass.machinesEntities.ModelsMachine.ToList();
				CBClient.SelectedItem = StorageClass.machinesEntities.Users.Find(machine.user_id);
				CBManager.SelectedItem = StorageClass.machinesEntities.Users.Find(machine.manager);
				CBEngineer.SelectedItem = StorageClass.machinesEntities.Users.Find(machine.engineer);
				CBTechnican.SelectedItem = StorageClass.machinesEntities.Users.Find(machine.technician);
				isNew = false;
				foreach (PaymentTypes type in machine.PaymentTypes) {
					switch (type.PaymentType)
					{
						case "Наличные":
							Kopur.IsChecked = true;
							break;
						case "Qr-код":
							QR.IsChecked = true;
							break;
						case "Карта":
							Modul.IsChecked = true;
							break;
						case "Монеты":
							Monet.IsChecked = true;
							break;
					}
				}
			}
			else
				CreateID();
			DataContext = machine;

			CBWorkMode.ItemsSource = StorageClass.machinesEntities.WorkModes.ToList();
			CBTimezone.ItemsSource = StorageClass.machinesEntities.Timezones.ToList();
			CBCrit.ItemsSource = StorageClass.machinesEntities.CriticalThresholdTemplate.ToList();
			CBUved.ItemsSource = StorageClass.machinesEntities.NotificationTemplates.ToList();
			CBClient.ItemsSource = StorageClass.machinesEntities.Users.ToList().Where(x => x.Roles.role == "Франчайзи");
			CBManager.ItemsSource = StorageClass.machinesEntities.Users.ToList().Where(x => x.is_manager == true);
			CBEngineer.ItemsSource = StorageClass.machinesEntities.Users.ToList().Where(x => x.is_engineer == true);
			CBTechnican.ItemsSource = StorageClass.machinesEntities.Users.ToList().Where(x => x.is_technician == true);
			CBPrioritet.ItemsSource = StorageClass.machinesEntities.ServicePriorities.ToList();
		}

		private void CreateID()
		{
			machine.id = "";
			String forID = "qwertyuioplkjhgfdsazx-cvbnm0123456789";
			Random random = new Random();
			for (int i = 1; i < 35; i++)
			{
				machine.id += forID[random.Next(37)];
			}
			VendingMachines find = StorageClass.machinesEntities.VendingMachines.Find(machine.id);
			if (find != null)
				CreateID();
		}

		private void Save(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();

			if (string.IsNullOrWhiteSpace(IName.Text))
				errors.AppendLine("Введите название");
			if (string.IsNullOrWhiteSpace(IAddress.Text))
				errors.AppendLine("Введите адресс");
			if (string.IsNullOrWhiteSpace(IPlace.Text))
				errors.AppendLine("Введите место");
			if (string.IsNullOrWhiteSpace(INumber.Text))
				errors.AppendLine("Введите номер");
			if (string.IsNullOrWhiteSpace(IWorkTime.Text))
				errors.AppendLine("Введите время работы");

			if (CBModel.SelectedIndex == -1)
				errors.AppendLine("Выберите модель");
			if (CBWorkMode.SelectedIndex == -1)
				errors.AppendLine("Выберите режим работы");
			if (CBTimezone.SelectedIndex == -1)
				errors.AppendLine("Выберите часовой пояс");
			if (CBPrioritet.SelectedIndex == -1)
				errors.AppendLine("Выберите приоритет ремонта");

			if (CBClient.SelectedIndex > -1)
				machine.user_id = ((CBClient.SelectedItem) as Users).id;
			if (CBManager.SelectedIndex > -1)
				machine.manager = ((CBManager.SelectedItem) as Users).id;
			if (CBEngineer.SelectedIndex > -1)
				machine.engineer = ((CBEngineer.SelectedItem) as Users).id;
			if (CBTechnican.SelectedIndex > -1)
				machine.technician = ((CBTechnican.SelectedItem) as Users).id;

			if (errors.Length > 0)
			{
				MessageBox.Show(errors.ToString());
			}
			else
			{
				if (isNew)
				{
					StorageClass.machinesEntities.VendingMachines.Add(machine);
					machine.company = 1;
				}
				StorageClass.machinesEntities.SaveChanges();
				MessageBox.Show("информация сохранена");

			}
		}
		private void Cancel(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private async void Metod_Chenged(object sender, RoutedEventArgs e)
		{
			CheckBox box = sender as CheckBox;
			PaymentTypes type = new PaymentTypes();
			switch (box.Name)
			{
				case "Monet":
					type = StorageClass.machinesEntities.PaymentTypes.Find(4);
					break;
				case "Kopur":
					type = StorageClass.machinesEntities.PaymentTypes.Find(1);
					break;
				case "Modul":
					type = StorageClass.machinesEntities.PaymentTypes.Find(3);
					break;
				case "QR":
					type = StorageClass.machinesEntities.PaymentTypes.Find(2);
					break;
			}
			if (box.IsChecked == false)
				machine.PaymentTypes.Remove(type);
			else
				machine.PaymentTypes.Add(type);
		}

		private void CompanySelect(object sender, SelectionChangedEventArgs e)
		{
			TextBlock comp = ((ComboBox)sender).SelectedItem as TextBlock;
			CBModel.ItemsSource = StorageClass.machinesEntities.ModelsMachine.ToList().Where(x => x.Model.Contains(comp.Text));
		}
	}
}
