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
    public class FurnitureViewModel : IViewModel<FurnitureViewModel>
    {
        public FurnitureViewModel(IService<Furniture> furnitureService, IService<Room> roomService)
        {
            this.furnitureService = furnitureService;
            this.roomService = roomService;
            Furnitures = furnitureService.GetObservable();
            Furniture = new Furniture();
            Rooms = roomService.GetObservable();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
            _clearCommand = new DelegateCommand(Clear);
        }
        #region fields
        private ObservableCollection<Furniture> furnitures;
        private Furniture furniture;
     
        private ObservableCollection<Room> rooms;
        private IService<Furniture> furnitureService;
        private IService<Room> roomService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _clearCommand;
        private readonly DelegateCommand _editCommand;
        #endregion
        #region properties
        public ObservableCollection<Furniture> Furnitures { get { return furnitures; } set { furnitures = value; NotifyPropertyChanged("Furnitures"); } }
        public ObservableCollection<Room> Rooms { get { return rooms; } set { rooms = value; NotifyPropertyChanged("Rooms"); } }
        public Furniture Furniture { get { return furniture; } set { furniture = value; NotifyPropertyChanged("Furniture"); } }
       
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
        public DelegateCommand ClearCommand { get { return _clearCommand; } }
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
        private void Clear(object o)
        {
            Furniture = new Furniture();
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
                furnitureService.Remove(furniture);
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
