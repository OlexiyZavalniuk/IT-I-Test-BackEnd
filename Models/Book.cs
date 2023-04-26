using System;

namespace Models
{
	public class Book0
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime Date { get; set; }

		public int Pages { get; set; }
	}

	public class Book : Book0
	{
		public int Id { get; set; }
	}
}
