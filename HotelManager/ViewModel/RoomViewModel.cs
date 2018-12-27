using HotelManager.Model.Context;
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
using Unity.Attributes;

namespace HotelManager.ViewModel
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        public RoomViewModel(IService<Room> roomService, FurnitureViewModel furnitureViewModel)
        {
            this.roomService = roomService;            
            FurnitureViewModel = furnitureViewModel;
            FurnitureViewModel.CollectionChangedEvent += OnInnerUpdate;
            CollectionChangedEvent += FurnitureViewModel.OnOuterUpdate;
            Room = new Room();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
        }
        #region fields
        private IService<Room> roomService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _editCommand;
        private Room room;
        #endregion
        #region properties
        public ObservableCollection<Room> Rooms { get { return roomService.Get().ToObservableCollection(); } }
        public Room Room { get { return room; } set { room = value; NotifyPropertyChanged("Room"); } }
        #endregion
        #region INotifyPropertyChanged Members
        public event NotifyCollectionChangedEventHandler CollectionChangedEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == "Rooms") CollectionChangedEvent.Invoke(null, null);

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
                Room r = new Room { Number = room.Number };
                roomService.Create(r);
                OnUpdate(null, null);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Edit(object o)
        {
            try
            {
               roomService.Update(Room);
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

                roomService.Remove(Room);
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
            NotifyPropertyChanged("Room");           
        }
        public void OnInnerUpdate(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Room");
        }
        #endregion
        #region ViewModels
        public FurnitureViewModel FurnitureViewModel
        {
            get; set;
        }
        #endregion
    }
}
