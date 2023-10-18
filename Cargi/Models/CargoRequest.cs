using Cargo.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cargo.Models
{
    public class CargoRequest : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private string _adress;

        public string Adress 
        {
            get => _adress;
            set
            {
                if (value != _adress)
                {
                    _adress = value;
                    OnPropertyChanged(nameof(Adress));
                }
            }
        }
        public Client Sender { get; set; }
        public Client Recipient { get; set; }
        public Courier Courier { get; set; }
        public Cargo Cargo { get; set; }

        private CargoState _state;

        public CargoState State 
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                    OnPropertyChanged(nameof(IsRequestNew));
                }
            }
        }

        private string _comment { get; set; }

        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        public bool IsRequestNew => State == CargoState.New;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public CargoRequest Clone()
        {
            return new CargoRequest
            {
                Id = this.Id,
                Adress = this.Adress,
                Sender = this.Sender?.Clone(),
                Recipient = this.Recipient?.Clone(),
                Courier = this.Courier?.Clone(),
                Cargo = this.Cargo?.Clone(),
                State = this.State
            };
        }

        public CargoRequest Init()
        {
            this.Cargo = new Cargo();
            this.Courier = new Courier();
            this.Sender = new Client();
            this.Recipient = new Client();
            return this;
        }
    }
}
