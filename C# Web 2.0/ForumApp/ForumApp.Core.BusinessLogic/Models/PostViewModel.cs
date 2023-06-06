﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.BusinessLogic.Models
{
	public class PostViewModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = null!;

		public string Content { get; set; } = null!;
	}
}
