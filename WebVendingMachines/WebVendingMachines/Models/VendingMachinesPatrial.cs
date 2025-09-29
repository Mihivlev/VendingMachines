using System;

namespace WebVendingMachines.Models
{
	public partial class VendingMachines
	{
		public string modem
		{
			get
			{
				string modem = "18241000";
				Random rnd = new Random();
				for (int i = 0; i < 2; i++)
					modem += rnd.Next(9).ToString();
				return modem;
			}
			set { }
		}
	}
}