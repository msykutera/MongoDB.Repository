using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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