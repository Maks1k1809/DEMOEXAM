using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TarasovMaximDemo.Entity;
using TarasovMaximDemo.Properties;

namespace TarasovMaximDemo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entity.TarasovEntities Context { get; set; } = new TarasovEntities();
        public static User AuthUser
        {
            get
            {
                return Context.User.Find(Settings.Default.UserID);
            }
        }

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Произошла непредвиденная ошибка в работе программы, проверьте подключение к базе данных. Если ошибка появится снова - обратитесь к вашему системному администратору.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information); ;
        }
    }
}
