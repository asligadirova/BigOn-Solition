using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BigOnDbContext db;

        public BrandsController(BigOnDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = db.Brands.Where(m => m.DeletedDate == null)
            .ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.Brands.FirstOrDefault(m => m.Id == id && m.DeletedDate == null);
            
            if (data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create(Brand model)
        {
            db.Brands.Add(model);
            db.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Brand model)
        {
            var entity = db.Brands.FirstOrDefault(m => m.Id == id);
            if (entity==null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            db.SaveChanges();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var entity = db.Brands.FirstOrDefault(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            db.Brands.Remove(entity);
            db.SaveChanges();
            return NoContent();
        }
    }
}
