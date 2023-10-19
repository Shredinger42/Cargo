using Cargi.Services;
using Cargo.Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cargo.ViewModels
{
    public class RequestViewModel : ViewModelBase, INotifyPropertyChanged, ISupportParentViewModel
    {
        private ICargoWebService _webService;
        public CargoRequest CargoRequest { get; set; }

        public object ParentViewModel { get; set; }

        private IEnumerable<Courier> _couriers;
        public IEnumerable<Courier> Couriers 
        {
            get => _couriers;
            set
            {
                _couriers = value;
                OnPropertyChanged(nameof(Couriers));
            }
        }

        public IDialogService EditDialogService { get; set; }
        public IDialogService SubmittDialogService { get; set; }
        public List<CargoState> CargoStates => new List<CargoState>
        {
            CargoState.Canceled,
            CargoState.Done,
            CargoState.New,
            CargoState.Submitted
        };

        private bool _isStateCanceled;
        public bool IsStateCanceled
        {
            get => _isStateCanceled;
            set
            {
                if (_isStateCanceled != value)
                {
                    _isStateCanceled = value;
                    OnPropertyChanged(nameof(IsStateCanceled));
                }
            }
        }

        private bool _isStateSubmitted;
        public bool IsStateSubmitted
        {
            get => _isStateSubmitted;
            set
            {
                if (_isStateSubmitted != value)
                {
                    _isStateSubmitted = value;
                    OnPropertyChanged(nameof(IsStateSubmitted));
                }
            }
        }

        public CargoState SelectedState
        {
            get => CargoRequest.State;
            set
            {
                if (CargoRequest.State != value)
                {
                    CargoRequest.State = value;
                    IsStateCanceled = CargoRequest.State == CargoState.Canceled;
                    IsStateSubmitted = CargoRequest.State == CargoState.Submitted;
                }
            }
        }

        public RequestViewModel(IEnumerable<Courier> couriers, CargoRequest cargoRequest, ICargoWebService webService)
        {
            Couriers = couriers;
            CargoRequest = cargoRequest;
            _webService = webService;
            EditDialogService = GetService<IDialogService>("Edit");
            SubmittDialogService = GetService<IDialogService>("Submitt");
        }

        /// <summary>
        /// Команда для открытия диалогового окна редактирования заявки
        /// </summary>
        /// <returns></returns>
        [Command]
        public async Task ShowEdit()
        {
            var dialogVm = new RequestViewModel(Couriers, CargoRequest, _webService)
            {
                CargoRequest = CargoRequest.Clone()
            };

            var result = EditDialogService.ShowDialog(
                 dialogButtons: MessageButton.OKCancel,
                 title: "Редактировать",
                 viewModel: dialogVm);
            if (result == MessageResult.OK)
            {
                await Save(dialogVm.CargoRequest);
            }
        }

        /// <summary>
        /// Команда для открытия диалогового откна создания новой заявки
        /// </summary>
        /// <returns></returns>
        [Command]
        public async Task ShowSubmit()
        {
            var dialogVm = new RequestViewModel(Couriers, CargoRequest, _webService)
            {
                CargoRequest = CargoRequest.Clone()
            };

            var result = SubmittDialogService.ShowDialog(
                 dialogButtons: MessageButton.OKCancel,
                 title: "Назначить курьера",
                 viewModel: dialogVm);
            if (result == MessageResult.OK)
            {
                await ChangeCourierAndState(dialogVm.CargoRequest);
            }
        }

        private async Task Save(CargoRequest editedCardoRequest)
        {
            await _webService.UpdateCargoRequest(editedCardoRequest);
            if (ParentViewModel is RequestsViewModel vm)
            {
                vm.Load();
            }
        }
   
        private async Task ChangeCourierAndState(CargoRequest editedCardoRequest)
        {
            var courier = editedCardoRequest.Courier;
            var cargo = editedCardoRequest.Cargo;
            await _webService.SubmittCargoRequest(courier.Id, cargo.Id, editedCardoRequest.Id);
            if (ParentViewModel is RequestsViewModel vm)
            {
                vm.Load();
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
