using API_DEMO.DTOs.Product;
using API_DEMO.Models;

namespace API_DEMO.Mappers
{
    public static class ProductMappers
    {
        public static ProductDTOs ToProductFromDTOs(this Product productModel)
        {
            return new ProductDTOs
            { 
                SpId = productModel.SpId,
                Name = productModel.Name,
                CategoryId = productModel.CategoryId,
                Description = productModel.Description,
                Quantity = productModel.Quantity,
                Price = productModel.Price,
                Image = productModel.Image,
                CreatedBy = productModel.CreatedBy,
                CreatedAt = productModel.CreatedAt,
                EditedBy = productModel.EditedBy,
                EditedAt = productModel.EditedAt,
                //OrderDetails = productModel.OrdersDetails.Select(e => e.ToOrderDetailFromDTOs()).ToList()

            };
        }

        public static Product ToProductCreateFromDTOs(this CreateProductDTOs productDTOs, int categoryId)
        {
            return new Product
            { 
                Name = productDTOs.Name,
                CategoryId = categoryId,
                Description = productDTOs.Description,
                Quantity = productDTOs.Quantity,
                Price = productDTOs.Price,
                Image = productDTOs.Image,
                CreatedBy = productDTOs.CreatedBy,
                EditedBy = productDTOs.EditedBy
            };
        }

        public static Product ToProductUpdateFromDTOs(this UpdateProductDTOs productDTOs) 
        {
            return new Product
            {
                Name = productDTOs.Name,
                Description = productDTOs.Description,
                Quantity = productDTOs.Quantity,
                Price = productDTOs.Price,
                Image = productDTOs.Image,
                CreatedBy = productDTOs.CreatedBy,
                EditedBy = productDTOs.EditedBy

            };
        }
    }
}
