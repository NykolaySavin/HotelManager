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

namespace HotelManager.ViewModel
{
    public class AdminViewModel : EmployeeViewModel, INotifyPropertyChanged
    {
        public AdminViewModel(IRoomService roomService):base(roomService)
        {
            this.roomService = roomService;
            Rooms = roomService.GetItems();
            _clearCommand = new DelegateCommand(Clear);
            _addEditCommand = new DelegateCommand(AddEdit);
        }
        #region fields
        private readonly DelegateCommand _clearCommand;
        private readonly DelegateCommand _addEditCommand;
        private List<Room> rooms;
        private IRoomService roomService;
        private Room room;
        #endregion
        #region properties
        public List<Room> Rooms { get { return rooms; }set { rooms = value; NotifyPropertyChanged("Rooms"); } }
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
        public DelegateCommand ClearCommand { get { return _clearCommand; } }
        public DelegateCommand AddEditCommand { get { return _addEditCommand; } }
        #endregion
        #region Methods
        private void AddEdit(object param)
        {
            if(Rooms.Contains(Room))
            {
                roomService.Edit(Room);
                Rooms = roomService.GetItems();
            }
            else
            {
                roomService.Add(Room);
                Rooms = roomService.GetItems();
            }
        }
        private void Clear(object param)
        {
            Room = new Room();
        }
        #endregion
    }
}
