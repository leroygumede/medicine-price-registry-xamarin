using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

namespace medicinepricechecker.Models
{
	//[Table("product")]
	[Table(nameof(Product))]
	public class Product : INotifyPropertyChanged
	{
		[NotNull, MaxLength(250)]
		public string name { get; set; }

		public string nappi_code { get; set; }

		public string schedule { get; set; }

		public string cost_per_unit { get; set; }

		public int num_packs { get; set; }

		public string dispensing_fee { get; set; }

		[Ignore]
		public IList<Ingredient> ingredients { get; set; }

		public double pack_size { get; set; }

		public string dosage_form { get; set; }

		public string is_generic { get; set; }

		public string regno { get; set; }

		public int id { get; set; }

		public string sep { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
	}
}