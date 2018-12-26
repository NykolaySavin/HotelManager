using HotelManager.Model.OrderDirectory;
using HotelManager.Model.Services;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManager.ViewModel
{
    public class FurnitureViewModel : IViewModel<FurnitureViewModel>, INotifyPropertyChanged
    {
        public FurnitureViewModel(IService<Furniture> furnitureService)
        {
            this.furnitureService = furnitureService;
            Furnitures = furnitureService.GetObservable();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        private ObservableCollection<Furniture> furnitures;
        private Furniture furniture;
        private ObservableCollection<Room> rooms;
        private IService<Furniture> furnitureService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _editCommand;
        #endregion
        #region properties
        public ObservableCollection<Furniture> Furnitures { get { return furnitures; } set { furnitures = value; NotifyPropertyChanged("Furnitures"); NotifyPropertyChanged("Rooms"); } }
        public Furniture Furniture { get {   return furniture; } set { furniture = value;  NotifyPropertyChanged("Furniture"); } }
        public ObservableCollection<Room> Rooms { get { return rooms; } set { rooms = value; NotifyPropertyChanged("Rooms"); } }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (furniture == null) Furniture= new Furniture();
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
                Furniture f = new Furniture() { Name = Furniture.Name, Price = Furniture.Price, Room = Furniture.Room};
                furnitureService.Create(f);
                Furnitures.Add(f);
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
                furnitureService.Update(furniture);
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
                furnitureService.Remove(Furniture);
                Furnitures.Remove(furniture);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}
