using HotelManager.Model.OrderDirectory;
using HotelManager.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManager.ViewModel
{
    public class ServiceTypeViewModel : INotifyPropertyChanged
    {
        public ServiceTypeViewModel(IService<ServiceType> serviceTypeService, ServiceViewModel serviceViewModel)
        {
            this.serviceTypeService = serviceTypeService;
          
            ServiceType = new ServiceType();
            ServiceViewModel = serviceViewModel;
            ServiceViewModel.CollectionChangedEvent += OnUpdate;
            
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _addServiceCommand = new DelegateCommand(AddService);
            _deleteServiceCommand = new DelegateCommand(DeleteService);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        private ObservableCollection<ServiceType> serviceTypes;
        private ObservableCollection<Service> services;
        private IService<ServiceType> serviceTypeService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _addServiceCommand;
        private readonly DelegateCommand _deleteServiceCommand;
        private readonly DelegateCommand _editCommand;
        private ServiceType serviceType;
        private Service service;
        #endregion
        #region properties
        public ObservableCollection<ServiceType> ServiceTypes {get{ return serviceTypeService.Get().ToObservableCollection(); } }
        public ObservableCollection<Service> FreeServices { get { return ServiceViewModel.Services.Except(ServiceType.Services,(x,y)=>x.Id==y.Id).ToObservableCollection(); }}
        public ObservableCollection<Service> Services { get { return ServiceType.Services.ToObservableCollection(); } }
        public ServiceType ServiceType { get { return serviceType; } set { if (value != null) serviceType = new ServiceType() { Id = value.Id, Services = value.Services, Type = value.Type }; NotifyPropertyChanged("ServiceType"); NotifyPropertyChanged("Services"); NotifyPropertyChanged("FreeServices"); } }
        public Service Service { get { return service; } set { service = value; NotifyPropertyChanged("Service"); } }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Commands
        public DelegateCommand AddCommand { get { return _addCommand; } }
        public DelegateCommand DeleteCommand { get { return _deleteCommand; } }
        public DelegateCommand AddServiceCommand { get { return _addServiceCommand; } }
        public DelegateCommand DeleteServiceCommand { get { return _deleteServiceCommand; } }
        public DelegateCommand EditCommand { get { return _editCommand; } }
        #endregion
        #region Methods
        private void Add(object o)
        {
            try
            {
                ServiceType s = new ServiceType { Type = ServiceType.Type };
                serviceTypeService.Create(s);
                OnUpdate(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void AddService(object o)
        {
            try
            {
                ServiceType.Services.Add(Service);
                this.Edit(null);
                //serviceTypeService.Update(ServiceType);
                //OnUpdate(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void DeleteService(object o)
        {
            try
            {
                ServiceType.Services.Remove(Service);
                this.Edit(null);
                //serviceTypeService.Update(ServiceType);
                //OnUpdate(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Edit(object o)
        {
            try
            {
                ServiceType s = serviceTypeService.FindById(ServiceType.Id);
                s.Services = ServiceType.Services;
                s.Type = ServiceType.Type;
                serviceTypeService.Update(s);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                OnUpdate(null, null);
            }
        }
        private void Delete(object o)
        {
            try
            {
                ServiceType s = serviceTypeService.FindById(ServiceType.Id);
                serviceTypeService.Remove(s);
                OnUpdate(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void OnUpdate(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("ServiceTypes");
            NotifyPropertyChanged("ServiceType");
            Service = null;
            NotifyPropertyChanged("Service");
            NotifyPropertyChanged("Services");
            NotifyPropertyChanged("FreeServices");          
        }
        #endregion
        #region ViewModels
        public ServiceViewModel ServiceViewModel
        {
            get; set;
        }
        #endregion
    }
}

