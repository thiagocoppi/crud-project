using System.Collections.Generic;
using System.Linq;

namespace Domain.Base
{
    public class NotificationResults
    {
        public bool Valid { get; private set; }
        public IList<Notification> Errors { get; set; }

        public NotificationResults(IList<Notification> errors)
        {
            Errors = errors;
            Valid = errors.Any() ? false : true;
        }
    }
}