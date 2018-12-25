using HotelManager.Model.Context;
using HotelManager.Model.OrderDirectory;
using HotelManager.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public RoomViewModel(IService<Room> roomService)
        {
            this.roomService = roomService;
            Rooms = roomService.GetItems();
            Room = Rooms.FirstOrDefault();
            _addCommand = new DelegateCommand(Add);
            _deleteCommand = new DelegateCommand(Delete);
            _editCommand = new DelegateCommand(Edit);
            _clearCommand = new DelegateCommand(Clear);
        }
        #region fields
        private ObservableCollection<Room> rooms;
        private ObservableCollection<Furniture> furniture;
        private IService<Room> roomService;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _clearCommand;
        private readonly DelegateCommand _editCommand;
        private Room room;
        #endregion
        #region properties
        public ObservableCollection<Room> Rooms { get { return rooms; }set { rooms = value; NotifyPropertyChanged("Rooms"); } }
        public ObservableCollection<Furniture> Furniture { get { return furniture; } set { furniture = value; NotifyPropertyChanged("Furniture"); } }
        public Room Room { get { return room; } set { room = value; NotifyPropertyChanged("Room"); } }
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
                roomService.Add(room);
                Rooms.Add(room);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Clear(object o)
        {
            Room = new Room();
        }
        private void Edit(object o)
        {
            try
            {
                roomService.Edit(room);
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
                roomService.Delete(room);
                Rooms.Remove(room);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
        #region ViewModels
        [Dependency]
        public FurnitureViewModel FurnitureViewModel
        {
            get; set;
        }
        #endregion
    }
}
