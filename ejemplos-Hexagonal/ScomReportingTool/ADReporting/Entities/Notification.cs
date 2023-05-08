using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADReporting.Entities
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationID { get; set; }
        public string AlertName { get; set; }
        public string AlertDescription { get; set; }
        public int Type { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string DestinataryMails { get; set; }
        public string CCMails { get; set; }
        [ForeignKey("AlertID")]
        public int? AlertID { get; set; }
    }
}
