using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Sample
{
    internal class NotificationViewModel
    {
     
        public ObservableCollection<Notification> Notifications { get; set; }

  
        public NotificationViewModel()
        {
            Notifications = new ObservableCollection<Notification>();
     
            Notification a = new Notification();
            a.Heading = "Heading";
            a.Description = "Description";
            a.ImageUri = "https://uat.performax360.com/Assets/images/performax.png";
            for (int i = 0; i < 15; i++)
                this.Notifications.Add(a);
        }
    }
}