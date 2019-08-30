using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRateWallet_WebAPI.DataAccess.Models
{
    public class DateTimeBase
    {
        public DateTime UpdateDatetime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDatetime { get; set; }
    }
}
