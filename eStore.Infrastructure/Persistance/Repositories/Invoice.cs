using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance.Repositories
{
    public class Invoice
    {
        [Key]
        [MaxLength(50)]
        public Guid InvoiceId         { get;  set; }
        public Guid? CustomerId        { get;  set; }

        public decimal?  TotalAmount     { get;  set; }
        public int?   Status          { get;  set; }
        public DateTime? CreatedOn       { get;  set; }

    }


}
