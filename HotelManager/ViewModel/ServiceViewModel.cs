using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using HotelManager.Model.Services;
using HotelManager.Model.OrderDirectory;
using System.Windows;

namespace HotelManager.ViewModel
{
    public class ServiceViewModel : INotifyPropertyChanged
    {
        public ServiceViewModel(IService<Service> serviceService)
        {
            this.serviceService = serviceService;
            Services = serviceService.GetObservable();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        private ObservableCollection<Service> services;
        private Service service;
        private ObservableCollection<ServiceType> serviceTypes;
        private IService<Service> serviceService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _editCommand;
        #endregion
        #region properties
        public ObservableCollection<Service> Services { get { return services; } set { services = value; NotifyPropertyChanged("Services"); NotifyPropertyChanged("ServiceTypes"); } }
        public Service CurrentService { get { return service; } set { service = value; NotifyPropertyChanged("CurrentService"); } }
    
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (service == null) CurrentService = new Service();
        }
        #endregion
        #region Commands
        public DelegateCommand AddCommand { get { return _addCommand; } }
        public DelegateCommand DeleteCommand { get { return _deleteCommand; } }
        public DelegateCommand EditCommand { get { return _editCommand; } }
        #endregion
        #region Methods
        private void Add(object o)
        {
            try
            {
                Service s = new Service() { Name = CurrentService.Name };
                serviceService.Create(s);
                Services.Add(s);
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
                serviceService.Update(CurrentService);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Delete(object o)
        {
            try
            {
                serviceService.Remove(CurrentService);
                Services.Remove(CurrentService);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
