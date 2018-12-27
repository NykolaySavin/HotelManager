using HotelManager.Model;
using HotelManager.Model.Context;
using HotelManager.Model.OrderDirectory;
using HotelManager.Model.Services;
using HotelManager.ViewModel.Autorization;
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
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        public EmployeeViewModel(IService<Employee> employeeService, IService<Service> serviceService)
        {
            this.employeeService = employeeService;
            this.serviceService = serviceService;
            Employee = new Employee();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        
        private IService<Employee> employeeService;
        private IService<Service> serviceService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _editCommand;
        private Employee employee;
        private Service service;
        #endregion
        #region properties
        public ObservableCollection<Service> Services { get { return serviceService.Get().ToObservableCollection(); } }
        public ObservableCollection<Employee> Employees { get { return  employeeService.Get().ToObservableCollection(); } }
        public Employee Employee { get { return employee; } set { employee =new Employee() {Name= value.Name,Surname= value.Surname,Phone= value.Phone,Email= value.Email,Role= value.Role, Service=value.Service, Id=value.Id } ; NotifyPropertyChanged("Employee"); } }
        public Service Service { get { return service; } set { service = value; NotifyPropertyChanged("Service"); } }
        public List<string> Roles { get { return new List<string>() { "Administrators", "None"}; }}
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           if (employee == null) Employee = new Employee();
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
                Employee e = new Employee(Employee.Name, Employee.Surname, Employee.Phone, Employee.Email, Employee.Role) { Service = Employee.Service};
                employeeService.Create(e);
                OnUpdate(null,null);
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
                Employee e = employeeService.FindById(Employee.Id);
                e.Name = Employee.Name;
                e.Phone = Employee.Phone;
                e.Role = Employee.Role;
                e.Service = Employee.Service;
                e.Surname = Employee.Surname;
                employeeService.Update(e);
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
                Employee e = employeeService.FindById(Employee.Id);
                employeeService.Remove(e);
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
            NotifyPropertyChanged("Employee");
            NotifyPropertyChanged("Employees");

        }
        #endregion
        #region ViewModels
        #endregion
    }
}

