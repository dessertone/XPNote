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

namespace XPNote.ViewModels
{
    partial class LoginViewModel : ObservableRecipient
    {
        private readonly IMessenger messenger;
        private readonly ILogger<LoginViewModel> logger;
        public User LogInUser { get; set; } = new User();
        public User RegisterUser { get; set; } = new User();

        public LoginViewModel(IMessenger messenger, ILogger<LoginViewModel> logger)
        {
            this.messenger=messenger;
            this.logger=logger;
        }

        [ObservableProperty]
        int selectedIndex;

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
                case "Return": SelectedIndex = 0; break;
            }

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
            logger.LogInformation("Login name: {0},password: {1}", LogInUser.UserName, LogInUser.Password);
        }
    }
}
