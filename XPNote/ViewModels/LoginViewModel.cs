using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using XPNote.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using XPNote.Services;
using System.Windows;
using XPNote.Views;

namespace XPNote.ViewModels
{
    partial class LoginViewModel : ObservableRecipient
    {
        private readonly IMessenger messenger;
        private readonly ILogger<LoginViewModel> logger;
        private readonly IWindowService windowService;

        public User LogInUser { get; set; } = new User();
        public User RegisterUser { get; set; } = new User();
        

        public LoginViewModel(IMessenger messenger, ILogger<LoginViewModel> logger,IWindowService windowService)
        {
            this.messenger=messenger;
            this.logger=logger;
            this.windowService=windowService;
        }
        #region ObservableProperties
        [ObservableProperty]
        int selectedIndex;
        [ObservableProperty]
        string? name;
        [ObservableProperty]
        string? email;
        [ObservableProperty]
        string? reNewPassword;
        [ObservableProperty]
        string? newPassword;
        [ObservableProperty]
        string? code;
        #endregion
        #region Commands
        [RelayCommand]
        void Excute(string method)
        {
            logger.LogInformation("LoginView excute:{0}",method);
            switch (method)
            {
                case "Login":Login(); break;
                case "NavigateRegister": NavigateRegister(); break;
                case "NavigateRetrieve": NavigateRetrieve(); break;
                case "Regeister": Register(); break;
                case "Retrieve": Retrieve(); break;
                case "Return": Return(); break;
            }

        }
        [RelayCommand]
        void Close(IWIndowClose window)
        {
            logger.LogInformation("Application shut down... ");
            window.CloseWindow();
            Application.Current.Shutdown();
        }
        [RelayCommand]
        void MiniMize(IWIndowClose window)
        {
            logger.LogInformation("Minimize login window");
            window.MiniMizeWindow();
        }
        #endregion

        private void Return()
        {
            logger.LogInformation("Navigate to login view");
            SelectedIndex = 0;
        }

        private void Retrieve()
        {
            logger.LogInformation("start retrieve password");
        }

        private void NavigateRetrieve()
        {
            logger.LogInformation("Navigate to retrieve password view");
            SelectedIndex = 2;
        }

        private void NavigateRegister()
        {
            logger.LogInformation("Navigate to register view");
            SelectedIndex = 1;
        }

        private void Register()
        {
            logger.LogInformation("Start register");

        }


        private void Login()
        {
            if (SelectedIndex!=0) return;
            if(string.IsNullOrEmpty(LogInUser.UserName) ||
               string.IsNullOrEmpty(LogInUser.Password))
            {
                logger.LogInformation("Login name or password is empty");
                return;
            }
            logger.LogInformation("Login name: {0},password: {1}", LogInUser.UserName, LogInUser.Password);
            windowService.NavigateTo(typeof(MainWindow));
            
        }
    }
}
