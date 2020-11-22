using System.Collections.Generic;

namespace Cybertron.Core.Interfaces.Services
{
    public interface INotificationService
    {
        List<string> Messages { get; }
        bool HasAny();
        void AddNotification(string message);
    }
}
