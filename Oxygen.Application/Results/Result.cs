using Flunt.Notifications;
using Oxygen.Domain.Enum;
using System.Collections.Generic;


namespace Oxygen.Application.Results
{
    public class Result : Notifiable
    {
        public Result()
        {
        }

        public Result(string error) => AddNotification(null, error);

        public Result(IReadOnlyCollection<Notification> notifications) => AddNotifications(notifications);

        public object Data { get; set; }


        public void AddNotifications(IReadOnlyCollection<Notification> notifications, ErrorCode errorCode)
        {
            AddNotifications(notifications);
            Error = errorCode;
        }

        public void AddNotification(string error, ErrorCode errorCode)
        {
            AddNotification(null, error);
            Error = errorCode;
        }

        public void AddNotification(string property, string message, ErrorCode errorCode)
        {
            AddNotification(property, message);
            Error = errorCode;
        }

        public void AddNotification(string error) => this.AddNotification(null, error);

        public void AddNotification(Notification notification, ErrorCode errorCode)
        {
            AddNotification(notification);
            Error = errorCode;
        }

        public ErrorCode? Error { get; set; }
    }
}
