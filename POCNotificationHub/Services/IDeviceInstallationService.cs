using POCNotificationHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POCNotificationHub.Services
{
    public interface IDeviceInstallationService
    {
        string Token { get; set; }
        bool NotificationsSupported { get; }
        string GetDeviceId();
        DeviceInstallation GetDeviceInstallation(params string[] tags);
    }
}
