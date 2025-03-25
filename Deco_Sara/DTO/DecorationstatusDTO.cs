using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.DTO
{
    public class DecorationstatusDTO
    {
        [Key]
        public int DecorationStatus_ID { get; set; }

        public string status_description { get; set; }

        public int Order_ID { get; set; }

        public DateTime lastupdatedby_date_time { get; set; }

        public string lastupdatedby_name { get; set; }
    }
}
