using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Desktop_VendingMachine.classes
{
	public partial class VendingMachines
	{
		public string status_color
		{
			get
			{
				switch (status)
				{
					case 1:
						return "#00bbff";
					case 3:
						return "#ff0000";
					default:
						return "#00ff00";
				}
			}
			set { }
		}
		public string operator_photo
		{
			get
			{
				switch (Operators.id)
				{
					case 1:
						return "/Resources/operators/Beeline.png";
					case 2:
						return "/Resources/operators/Mts.png";
					case 3:
						return "/Resources/operators/Megafon.png";
					default:
						return "/Resources/operators/Tele2.png";
				}
			}
			set { }
		}
		public string signal
		{
			get
			{
				Random rnd = new Random();
				switch (rnd.Next(5))
				{
					case 5:
						return "/Resources/operators/Signal5.png";
					case 3:
						return "/Resources/operators/Signal3.png";
					case 2:
						return "/Resources/operators/Signal2.png";
					default:
						return "/Resources/operators/Signal1.png";
				}
			}
			set { }
		}
		public string modem
		{
			get
			{
				string mod = "";
				Random rnd = new Random();
				for (int i = 0; i < 10; i++)
					mod += rnd.Next(9).ToString();
				return mod;
			}
		}
		public int load
		{
			get
			{
				Random rnd = new Random();
				return rnd.Next(100);
			}
			set { }
		}
		public string load_color
		{
			get
			{
				if (load < 30)
					return "#ff0000";
				else
					return "#00eeaa";
			}
			set { }
		}
		public int dop1
		{
			get
			{
				Random rnd = new Random();
				return rnd.Next(300);
			}
			set { }
		}
		public int dop2
		{
			get
			{
				Random random = new Random();
				return random.Next(dop1);
			}
			set { }
		}
	}
}
