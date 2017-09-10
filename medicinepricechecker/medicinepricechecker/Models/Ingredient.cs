using System.ComponentModel;
using SQLite;

namespace medicinepricechecker.Models
{
	[Table("ingredients")]
	public class Ingredient : INotifyPropertyChanged
	{

		public int strength { get; set; }

		public string unit { get; set; }

		public string name { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
