using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance.Repositories
{
    public class Product
    {
        [Key]
        [MaxLength(50)]
        public Guid    ProductId          { get; set; }
        public string?  Name              { get; set; }
        public string?  Barcode           { get; set; }
        public string?  Description       { get; set; }
        public string?  Category          { get; set; }
        public bool?    IsWeighted        { get; set; }
        public int  Status            { get; set; }
        public decimal? Price             { get; set; }
    }


}
