using POCNotificationHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POCNotificationHub.Services
{
    public interface IPushDemoNotificationActionService : INotificationActionService
    {
        event EventHandler<PushDemoAction> ActionTriggered;

        void TriggerNotification(string title, string body, IDictionary<string, string> data);
    }
}