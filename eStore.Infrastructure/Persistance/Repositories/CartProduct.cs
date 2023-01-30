using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Infrastructure.Persistance.Repositories
{

    [PrimaryKey(nameof(CartId), nameof(ProductId))]
    public class CartProduct
    {
        [MaxLength(50)]
        public Guid CartId { get; set; }
        [MaxLength(50)]
        public Guid ProductId { get; set; }
    }


}
