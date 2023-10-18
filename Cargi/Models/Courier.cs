using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cargo.Models
{
    public class Courier : INotifyPropertyChanged
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

        public List<Cargo> CargoToDeliver { get; set; }

        public Courier Clone()
        {
            return new Courier
            {
                Id = this.Id,
                Name = this.Name,
                CargoToDeliver = this.CargoToDeliver
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
