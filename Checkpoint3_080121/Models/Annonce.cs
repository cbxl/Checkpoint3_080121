using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Checkpoint3_080121.Models
{
	public class Annonce
	{
		public Int32 Id { get; set; }
		public String Title { get; set; }
		public String Body { get; set; }
		public float Price { get; set; }
		public User User {get; set;}
	}
}
