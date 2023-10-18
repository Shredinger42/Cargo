using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cargo.Models
{
    public class Cargo : INotifyPropertyChanged
    {
        public long Id { get; set; }
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private int _weight;
        public int Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        private decimal _price;

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public Cargo Clone()
        {
            return new Cargo
            {
                Id = this.Id,
                Name = this.Name,
                Weight = this.Weight,
                Price = this.Price
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
