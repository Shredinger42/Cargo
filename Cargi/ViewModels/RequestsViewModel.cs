using Cargo.Services;
using Cargo.Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cargi.Services;

namespace Cargo.ViewModels
{
    public class RequestsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICargoWebService _webService;
        public ObservableCollection<RequestViewModel> CargoRequests { get; set; }

        public List<Courier> Couriers { get; set; }

        private RequestViewModel _selectedItem;
        public RequestViewModel SelectedItem 
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                // Если вызывать команды из текущей VM, то необходимо пробрасывать сервисы внутрь дочерей vm 
                // т.к. devexpress не может их сам найти
                if (SelectedItem != null)
                {
                    SelectedItem.EditDialogService = GetService<IDialogService>("Edit");
                    SelectedItem.SubmittDialogService = GetService<IDialogService>("Submitt");
                }
                
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        protected IDialogService DialogService => GetService<IDialogService>();

        public RequestsViewModel()
        {
            CargoRequests = new ObservableCollection<RequestViewModel>();
            _webService = new CargoWebService();
        }

        public void Load()
        {
            CargoRequests.Clear();
            // Вызываем Load из синхронного метода инициализации View, поэтому пришлось использовать такой способ вызова 
            // асинхронного метода
            var couriersAwaiter = Task.Factory.StartNew(_webService.GetCouriers).GetAwaiter();
            var cargoRequestsAwaiter = Task.Factory.StartNew(_webService.GetCargoRequests).GetAwaiter();
            cargoRequestsAwaiter.OnCompleted(() =>
            {
                couriersAwaiter.OnCompleted(() =>
                {
                    var cargoRequests = cargoRequestsAwaiter.GetResult().Result;
                    var couriers = couriersAwaiter.GetResult().Result;
                    foreach (var item in cargoRequests)
                    {
                        var vm = new RequestViewModel(couriers, item, _webService)
                        {
                            ParentViewModel = this
                        };
                        CargoRequests.Add(vm);
                    }
                });
            });
        }

        /// <summary>
        /// Команда добавления новой заявки
        /// </summary>
        /// <returns></returns>
        [Command]
        public async Task AddNewRequest()
        {
            var cargoRequest = new CargoRequest().Init();
            var vm = new RequestViewModel(Couriers, cargoRequest, _webService);
            
            var result = DialogService.ShowDialog(
                 dialogButtons: MessageButton.OKCancel,
                 title: "Создать",
                 viewModel: vm);
            if (result == MessageResult.OK)
            {
                var cargo = vm.CargoRequest.Cargo;
                var recipient = vm.CargoRequest.Recipient;
                var sender = vm.CargoRequest.Sender;
                var adress = vm.CargoRequest.Adress;
                await _webService.CreateCargoRequest(cargo, recipient, sender, adress);
                Load();
            }
        }

        /// <summary>
        /// Команда удаления заявки
        /// </summary>
        /// <param name="request">ViewModel к которой привязана модель заявки</param>
        /// <returns></returns>
        [Command]
        public async Task DeleteRequest(RequestViewModel request)
        {
            await _webService.DeleteCargoRequest(request.CargoRequest.Id);
            Load();
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
