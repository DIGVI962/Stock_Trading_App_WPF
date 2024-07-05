using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ResponseClasses
{
    public class BSEScrips
    {
        [Key]
        public string SCRIP_CD { get; set; }
        public string Scrip_Name { get; set; }
        public string Status { get; set; }
        public string GROUP { get; set; }
        public string FACE_VALUE { get; set; }
        public string ISIN_NUMBER { get; set; }
        public string INDUSTRY { get; set; }
        public string scrip_id { get; set; }
        public string Segment { get; set; }
        public string NSURL { get; set; }
        public string Issuer_Name { get; set; }
        public string Mktcap { get; set; }
    }
}
