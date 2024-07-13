using API_DEMO.DTOs.Category;
using API_DEMO.Models;

namespace API_DEMO.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDTOs ToCategoryFromDTOs(this Category categoryModel)
        {
            return new CategoryDTOs
            {
                CategoryId = categoryModel.CategoryId,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                CreatedBy = categoryModel.CreatedBy,
                CreatedAt = categoryModel.CreatedAt,
                EditedBy = categoryModel.EditedBy,
                EditedAt = categoryModel.EditedAt,
                Products = categoryModel.Products.Select(e => e.ToProductFromDTOs()).ToList()
            };
        }

        public static Category ToCategoryCreateFromDTOs(this CreateCategoryDTOs categoryDTOs)
        {
            return new Category
            {
                Name = categoryDTOs.Name,
                Description = categoryDTOs.Description,
                CreatedBy = categoryDTOs.CreatedBy,
                EditedBy= categoryDTOs.EditedBy
            };
        }

        public static Category ToCategoryUpdateFromDTOs(this UpdateCategoryDTOs categoryDTOs)
        {
            return new Category
            {
                Name = categoryDTOs.Name,
                Description = categoryDTOs.Description,
                CreatedBy = categoryDTOs.CreatedBy,
                EditedBy = categoryDTOs.EditedBy
            };
        }
    }
}
