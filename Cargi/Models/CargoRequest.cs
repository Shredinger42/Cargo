using Cargo.Utils;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cargo.Models
{
    public class CargoRequest : INotifyPropertyChanged
    {
        /// <summary>
        /// id Заявки
        /// </summary>
        public long Id { get; set; }

        private string _adress;

        /// <summary>
        /// Адрес
        /// </summary>
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
        /// <summary>
        /// Отправитель
        /// </summary>
        public Client Sender { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public Client Recipient { get; set; }
        /// <summary>
        /// Курьер
        /// </summary>
        public Courier Courier { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public Cargo Cargo { get; set; }
        private CargoState _state;
        /// <summary>
        /// Состояние заявки
        /// </summary>
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

        /// <summary>
        /// Комментарий
        /// </summary>
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

        /// <summary>
        /// Является ли заявка новой
        /// </summary>
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
