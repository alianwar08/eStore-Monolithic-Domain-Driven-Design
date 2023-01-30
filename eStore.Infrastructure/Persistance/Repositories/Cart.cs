using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance.Repositories
{
    public class Cart
    {
        [Key]
        [MaxLength(50)]
        public Guid CartId { get; set; }
        public Guid CustomerID { get; set; }
      

    }


}
