using POCNotificationHub.Models;
using POCNotificationHub.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POCNotificationHub
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ServiceContainer.Resolve<IPushDemoNotificationActionService>()
        .ActionTriggered += NotificationActionTriggered;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        void NotificationActionTriggered(object sender, PushDemoAction e)
    => ShowActionAlert(e);

        void ShowActionAlert(PushDemoAction action)
            => MainThread.BeginInvokeOnMainThread(()
                => MainPage?.DisplayAlert("PushDemo", $"{action} action received", "OK")
                    .ContinueWith((task) => { if (task.IsFaulted) throw task.Exception; }));
    }
}
