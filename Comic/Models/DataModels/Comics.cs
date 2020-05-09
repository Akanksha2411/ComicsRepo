using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Comic.Models.DataModels
{
    public class Comics
    {
        [Key]
        public int ID { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }
    }
}