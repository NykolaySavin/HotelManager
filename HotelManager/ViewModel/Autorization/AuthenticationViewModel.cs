using HotelManager.Model;
using HotelManager.Model.Autorization;
using HotelManager.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HotelManager.ViewModel.Autorization
{
    public interface IViewModel { }

    public class AuthenticationViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly AsyncCommand<object> _loginCommand;
        private string _username;
        private string _status;
        private bool isActive;
        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new AsyncCommand<object>(Login, CanLogin);
            isActive = false;
            
        }

        #region Properties
        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; NotifyPropertyChanged("IsActive"); NotifyPropertyChanged("IsInActive"); }
        }
        public bool IsInActive
        {
            get { return !isActive; }

        }
        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged("Status"); }
        }

        #endregion

        #region Commands
        public AsyncCommand<object> LoginCommand { get { return _loginCommand; } }
        #endregion

        private async Task Login(object parameter)
        {

            PasswordBox passwordBox = parameter as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            try
            {
                //Validate credentials through the authentication service
                Employee user =await Task.Factory.StartNew(()=> _authenticationService.AuthenticateUser(Username, clearTextPassword));
                if(user==null)
                    throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
                //Get the current principal object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Role);

                //Update UI
                NotifyPropertyChanged("AuthenticatedUser");
                NotifyPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                Username = string.Empty; //reset
                passwordBox.Password = string.Empty; //reset
                Status = string.Empty;
                if(user.Role=="Administrators")
                {
                    Pages.SetPage(Pages.AdminControl);
                }
                else
                {
                    Pages.SetPage(Pages.EmployeeControl);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
            finally
            {
                IsActive = false;
            }
        }

        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        


        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

     

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
