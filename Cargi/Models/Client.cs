using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cargo.Models
{
    public class Client : INotifyPropertyChanged
    {
        /// <summary>
        /// id клиента
        /// </summary>
        public long Id { get; set; }

        private string _name;

        /// <summary>
        /// Наименование клиента
        /// </summary>
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

        public Client Clone()
        {
            return new Client
            {
                Id = this.Id,
                Name = this.Name
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
