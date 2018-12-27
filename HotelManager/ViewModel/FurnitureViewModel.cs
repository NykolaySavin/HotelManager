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
    public class FurnitureViewModel : IViewModel<FurnitureViewModel>, INotifyPropertyChanged
    {
        public FurnitureViewModel(IService<Furniture> furnitureService, IService<Room> roomService)
        {
            this.furnitureService = furnitureService;
            this.roomService = roomService;
             Furniture = new Furniture();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        private Furniture furniture;
        private IService<Furniture> furnitureService;
        private IService<Room> roomService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _editCommand;
        #endregion
        #region properties
        public ObservableCollection<Furniture> Furnitures { get { return furnitureService.Get().ToObservableCollection(); } }
        public Furniture Furniture { get { return furniture; } set { furniture = value; NotifyPropertyChanged("Furniture"); } }
        public ObservableCollection<Room> Rooms { get { return roomService.Get().ToObservableCollection(); } }
        #endregion
        #region INotifyPropertyChanged Members
        public event NotifyCollectionChangedEventHandler CollectionChangedEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == "Furniture" && Furniture!=null) CollectionChangedEvent.Invoke(null, null);
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
                furnitureService.Update(furniture);
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
                furnitureService.Remove(Furniture);
                OnUpdate(null, null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void OnUpdate(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Rooms");
            NotifyPropertyChanged("Furniture");
            NotifyPropertyChanged("Furnitures");
        }
        public void OnOuterUpdate(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Rooms");
        }
        #endregion
    }
}
