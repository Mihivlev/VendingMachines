using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_VendingMachine.classes
{
	public partial class SettingTypes
	{
		public string photo
		{
			get 
			{
				return "/Resources/icons/settings/" + setting;
			}
			set { }
		}
	}
}
