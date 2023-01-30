using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Contracts.DTOs
{
    public record InvoiceDto
    {
        public string InvoiceId          { get;  set; }
        public string CustomerId         { get;  set; }

        public decimal  TotalAmount      { get;  set; }
        public string   Status           { get;  set; }
        public DateTime? CreatedOn       { get;  set; }
    }


}
