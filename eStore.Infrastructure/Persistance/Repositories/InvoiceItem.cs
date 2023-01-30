using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance.Repositories
{
    public class InvoiceItem
    {
        [Key]
        [MaxLength(50)]
        public Guid InvoiceItemId     { get; set;  }
        public Guid InvoiceId         { get;  set; }
        public Guid? ProductId         { get; set; }
        public decimal?  Amount          { get;  set; }
    }


}
