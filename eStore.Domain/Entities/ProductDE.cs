using eStore.Core.Exceptions;
using ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eStore.Domain.Entities
{
    public class ProductDE
    {
        private ProductDE()
        { 

        }

        public Guid ProductId            { get; private set; }
        public string Name               { get; private set; }
        public string Barcode            { get; private set; }
        public string Description        { get; private set; }
        public string Category           { get; private set; }
        public bool?  IsWeighted         { get; private set; }
        public ProductStatus Status      { get; private set; }
        public decimal Price { get; private set; }


        public void ChangeStatus(ProductStatus NewStatusID)
        {
            Status = NewStatusID;
        }


        public static ProductDE Create(
                            string name,
                            string barcode,
                            string description,
                            string category,
                            bool isWeighted,
                            ProductStatus status,
                            decimal price,
                            Guid? productId =null
                          )
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Product name cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(barcode))
                throw new BusinessRuleException("Product barcode cannot be null or whitespace.");

            if (price < 0)
                throw new BusinessRuleException("Product price cannot be less than zero.");

            if (productId == null)
                productId = Guid.NewGuid();

            var c = new ProductDE();
            c.ProductId = productId.Value;
            c.Name = name;
            c.Barcode = barcode;
            c.Description = description;
            c.Category = category;
            c.IsWeighted = isWeighted;
            c.Status = status;
            c.Price = price;

            return c;
        }

    }


}
