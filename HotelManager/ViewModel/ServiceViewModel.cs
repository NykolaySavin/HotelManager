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
using System.Collections.Specialized;

namespace HotelManager.ViewModel
{
    public class ServiceViewModel : INotifyPropertyChanged
    {
        public ServiceViewModel(IService<Service> serviceService)
        {
            this.serviceService = serviceService;
            Service = new Service();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        private Service service;
        private IService<Service> serviceService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _editCommand;
        #endregion
        #region properties
        public ObservableCollection<Service> Services { get { return serviceService.Get().ToObservableCollection(); } }
        public Service Service { get { return service; } set { if (value != null) service = new Service() { Employees=value.Employees, Id = value.Id, Name= value.Name, ServiceTypes= value.ServiceTypes }; NotifyPropertyChanged("Service"); } }
    
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChangedEvent;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (service == null) Service = new Service();
            if(propertyName=="Services") CollectionChangedEvent.Invoke(null, null);
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
                Service s = new Service() { Name = Service.Name };
                serviceService.Create(s);
                OnUpdate(null, null);
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
                Service s = serviceService.FindById(Service.Id);
                s.Name = Service.Name;
                s.ServiceTypes = Service.ServiceTypes;
                s.Employees = Service.Employees;
                serviceService.Update(s);
                OnUpdate(null, null);
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
                Service s = serviceService.FindById(Service.Id);
                serviceService.Remove(s);
                OnUpdate(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void OnUpdate(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Services");
            NotifyPropertyChanged("Service");
        }
        #endregion
    }
}
