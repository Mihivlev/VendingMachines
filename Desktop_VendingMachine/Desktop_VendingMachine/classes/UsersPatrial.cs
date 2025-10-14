using System;
using System.IO;

namespace Desktop_VendingMachine.classes
{
	public partial class Users
	{
		public byte[] Photo {
			get
			{
				if (image != null)
					return Convert.FromBase64String(image);
				String way = AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("bin\\Debug\\", "") + "Resources/Logo.png";
				return File.ReadAllBytes(way);
			}
			set { }
		}

	}
}
