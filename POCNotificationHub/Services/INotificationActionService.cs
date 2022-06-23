using System;
using System.Collections.Generic;
using System.Text;

namespace POCNotificationHub.Services
{
    public interface INotificationActionService
    {
        void TriggerAction(string action);
    }
}