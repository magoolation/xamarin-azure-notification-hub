using POCNotificationHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.UI;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;

namespace POCNotificationHub.Services
{
    public class PushDemoNotificationActionService : IPushDemoNotificationActionService
    {
        readonly Dictionary<string, PushDemoAction> _actionMappings = new Dictionary<string, PushDemoAction>
        {
            { "action_a", PushDemoAction.ActionA },
            { "action_b", PushDemoAction.ActionB }
        };

        public event EventHandler<PushDemoAction> ActionTriggered = delegate { };

        public void TriggerAction(string action)
        {
            if (!_actionMappings.TryGetValue(action, out var pushDemoAction))
                return;

            List<Exception> exceptions = new List<Exception>();

            foreach (var handler in ActionTriggered?.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, pushDemoAction);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }

        public void TriggerNotification(string title, string body, IDictionary<string, string> data)
        {
            App.Current.MainPage.DisplaySnackBarAsync(body, "OK", () => Task.CompletedTask);
        }
    }
}