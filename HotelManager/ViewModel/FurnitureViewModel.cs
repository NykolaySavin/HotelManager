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

namespace HotelManager.ViewModel
{
    public class FurnitureViewModel : IViewModel<FurnitureViewModel>
    {
        public FurnitureViewModel(IService<Furniture> furnitureService)
        {
            this.furnitureService = furnitureService;
            Furniture = furnitureService.GetItems();
        }
        #region fields
        private ObservableCollection<Furniture> furniture;
        private IService<Furniture> furnitureService;
        #endregion
        #region properties
        public ObservableCollection<Furniture> Furniture { get { return furniture; } set { furniture = value; NotifyPropertyChanged("Furniture"); } }
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
        #endregion
        #region Methods
        #endregion
    }
}
