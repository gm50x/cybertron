using Cybertron.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Cybertron.Core.Services
{
    public class NotificationService : INotificationService
    {
        public List<string> Messages { get; private set; }
        public NotificationService()
        {
            Messages = new List<string>();
        }
        public void AddNotification(string message)
        {
            if (!string.IsNullOrEmpty(message))
                Messages.Add(message);
        }

        public bool HasAny()
        {
            return Messages.Any();
        }
    }
}
