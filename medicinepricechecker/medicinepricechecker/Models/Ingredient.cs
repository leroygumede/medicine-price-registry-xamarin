using System;
using System.ComponentModel;

namespace medicinepricechecker.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        public double strength { get; set; }
        public string unit { get; set; }
        public string name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
