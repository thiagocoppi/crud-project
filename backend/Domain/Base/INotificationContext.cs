using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Base
{
    public interface INotificationContext
    {
        void AddNotification(string key, string message);

        void AddNotification(Notification notification);

        void AddNotifications(IReadOnlyCollection<Notification> notifications);

        void AddNotifications(IList<Notification> notifications);

        void AddNotifications(ICollection<Notification> notifications);

        void AddNotifications(ValidationResult validationResult);

        bool HaveNotification();

        NotificationResults GetErrors();
    }
}