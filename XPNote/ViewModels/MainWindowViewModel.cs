using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;
using XPNote.Services;
using XPNote.Views;

namespace XPNote.ViewModels
{
    partial class MainWindowViewModel :ObservableObject
    {
        private readonly IConfiguration configuration;
        private readonly IMessenger messager;
        private readonly IServiceProvider serviceProvider;
        private readonly IWindowService windowService;
        private readonly ILogger<MainWindowViewModel> logger;

        public MainWindowViewModel(
            IConfiguration configuration,
            IMessenger messager,
            IServiceProvider serviceProvider,
            IWindowService windowService,
            ILogger<MainWindowViewModel> logger)
        {
            this.configuration=configuration; 
            this.messager=messager;
            this.serviceProvider=serviceProvider;
            this.windowService=windowService;
            this.logger=logger;
        }
        #region ObservableProperties
        #endregion
        #region Commands
        [RelayCommand]
        void Close()
        {
            logger.LogInformation("注销用户");
            windowService.NavigateTo(typeof(LoginView));
        }
        #endregion
    }
}
