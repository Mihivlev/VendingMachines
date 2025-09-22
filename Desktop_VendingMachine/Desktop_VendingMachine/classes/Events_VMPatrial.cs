using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_VendingMachine.classes
{
	public partial class Events_VM
	{
		public string Photo
		{
			get 
			{
				switch (id_event)
				{
					case 1:
						return "/Resources/icons/blue/Sale.png";
					case 2:
						return "/Resources/icons/blue/Encashment.png";
					default:
						return "/Resources/icons/blue/Service.png";
				}
			}
			set { }
		}
	}
}
