using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPNote.ViewModels
{
    partial class MainWindowViewModel:ObservableObject
    {
        private readonly IConfiguration configuration;
        private readonly IMessenger messager;
        private readonly IServiceProvider serviceProvider;
        public MainWindowViewModel(IConfiguration configuration, IMessenger messager, IServiceProvider serviceProvider)
        {
            this.configuration=configuration; 
            this.messager=messager;
            this.serviceProvider=serviceProvider;
        }
    }
}
