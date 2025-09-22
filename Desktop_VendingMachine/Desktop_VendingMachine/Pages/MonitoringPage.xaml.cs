using Desktop_VendingMachine.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Desktop_VendingMachine.Pages
{
	/// <summary>
	/// Логика взаимодействия для MonitoringPage.xaml
	/// </summary>
	public partial class MonitoringPage : Page
	{
		bool isWorking = false;
		bool isInService = false;
		bool isBroken = false;

		public MonitoringPage()
		{
			InitializeComponent();
			LoadData(false);

		}

		private void LoadData(bool WithFilters)
		{
			List<VendingMachines> list = StorageClass.machinesEntities.VendingMachines.ToList();

			if (WithFilters)
			{
				//SettingTypes types = StorageClass
				DGMonitoring.ItemsSource = StorageClass.machinesEntities.VendingMachines.ToList().Where(v => ((v.status == 1 && isInService) || (v.status == 2 && isWorking) || (v.status == 3 && isBroken)));
			}
			else
				DGMonitoring.ItemsSource = list;

			TBallVM.Text = list.Count.ToString();
			int countWorking = 0;
			int countInService = 0;
			int countBroken = 0;
			int countMoney = 0;
			int sdacha = 0;

			for (int i = 0; i < list.Count; i++)
			{
				countMoney += (int)list[i].monets + (int)list[i].kopurs;
				sdacha += (int)list[i].sdacha;
				switch (list[i].status)
				{
					case 1:
						countInService++;
						break;
					case 3:
						countWorking++;
						break;
					default:
						countBroken++;
						break;
				}
			}

			TBWorking.Text = countWorking.ToString();
			TBinService.Text = countInService.ToString();
			TBBroken.Text = countBroken.ToString();
			TBMoney.Text = "Денег в автоматах: " + countMoney.ToString() + " р. + " + sdacha.ToString() + "р. (сдача)";
		}

		private void DGMonitoring_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			e.Row.Header = (e.Row.GetIndex()+1).ToString();
		}

		private void StatusFilter_isWorking(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			if (isWorking)
			{
				border.Background = new SolidColorBrush(Colors.White);
				isWorking = false;
			}
			else
			{
				border.Background = new SolidColorBrush(Colors.LightGray);
				isWorking = true;
			}
		}

		private void StatusFilter_isInService(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			if (isInService)
			{
				border.Background = new SolidColorBrush(Colors.White);
				isInService = false;
			}
			else
			{
				border.Background = new SolidColorBrush(Colors.LightGray);
				isInService = true;
			}
		}

		private void StatusFilter_isBroken(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			if (isBroken)
			{
				border.Background = new SolidColorBrush(Colors.White);
				isBroken = false;
			}
			else
			{
				border.Background = new SolidColorBrush(Colors.LightGray);
				isBroken = true;
			}
		}

		private void WithFilter(object sender, System.Windows.RoutedEventArgs e)
		{
			LoadData(true);
		}

		private void WithoutFilter(object sender, System.Windows.RoutedEventArgs e)
		{
			LoadData(false);
			isBroken = false;
			isInService = false;
			isWorking = false;
			btnBroken.Background = new SolidColorBrush(Colors.White);
			btnInService.Background = new SolidColorBrush(Colors.White);
			btnWorking.Background = new SolidColorBrush(Colors.White);
		}
	}
}
