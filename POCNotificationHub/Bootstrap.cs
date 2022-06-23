using POCNotificationHub.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POCNotificationHub
{
    public static class Bootstrap
    {
        public static void Begin(Func<IDeviceInstallationService> deviceInstallationService)
        {
            ServiceContainer.Register(deviceInstallationService);

            ServiceContainer.Register<IPushDemoNotificationActionService>(()
                => new PushDemoNotificationActionService());

            ServiceContainer.Register<INotificationRegistrationService>(()
                => new NotificationRegistrationService(
                    Config.BackendServiceEndpoint));
        }
    }
}