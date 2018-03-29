using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Repository.Example
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("get")]
        public IEnumerable<CategoryViewModel> Get()
        {
            var categories = _categoryRepository.AsQueryable()
                .Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    Status = x.Status,
                });

            return categories;
        }

        [HttpPost("add")]
        public void Add([FromBody] CategoryViewModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                Status = model.Status,
            };
            _categoryRepository.Add(category);
        }
    }
}