using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XPNote.Services
{
    class WindowService : IWindowService
    {
        private readonly IServiceProvider serviceProvider;

        public WindowService(IServiceProvider serviceProvider)
        {
            this.serviceProvider=serviceProvider;
        }
        public void NavigateTo(Type type)
        {
            var curWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            curWindow?.Close();
            var mainWindow = serviceProvider.GetService(type) as Window;
            mainWindow!.Show();
        }
    }
}
