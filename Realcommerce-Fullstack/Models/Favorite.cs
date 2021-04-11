using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Realcommerce_Fullstack.Models
{
	public class Favorite
	{
		[Key]
		public string Key { get; set; }
		public string LocalizedName { get; set; }

		
	}
}
