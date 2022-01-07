using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kuantum.Models;
using Microsoft.EntityFrameworkCore;

namespace Kuantum.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase {

        [HttpGet]
        public async Task<JsonResult> GetAllAsync() {
            using (var context = new kuantumContext()) {
                var aux = await context.Documents.Include(x => x.DocumentPageIndices).ToListAsync();
                return new JsonResult(aux);
            }
        }

        [HttpPost]
        public async Task InsertAsync(Document document) {
            document.Created_at = DateTime.Now;
            DateTime? date = null;
            document.Updated_at = date;
            document.Deleted_at = date;
            int page = 1;
            foreach (DocumentPageIndex item in document.DocumentPageIndices) {
                item.Created_at = DateTime.Now;
                item.Page = page;
                page++;
            }
            using (var context = new kuantumContext()) {
                context.Documents.Add(document);
                await context.SaveChangesAsync();
            }
        }

        [HttpPut]
        public async Task UpdateAsync(Document document) {
            document.Updated_at = DateTime.Now;
            DateTime? date = null;
            document.Deleted_at = date;
            int page = 1;
            foreach (DocumentPageIndex item in document.DocumentPageIndices) {
                item.Created_at = DateTime.Now;
                item.Page = page;
                page++;
            }
            using (var context = new kuantumContext()) {
                context.Documents.Update(document).Property(x => x.Created_at).IsModified = false;
                await context.SaveChangesAsync();
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<JsonResult> GetByIdAsync(int id) {
            using (var context = new kuantumContext()) {
                var aux = await context.Documents.Where(x => x.Id == id).FirstOrDefaultAsync();
                return new JsonResult(aux);
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<JsonResult> GetByNameAsync(string name) {
            using (var context = new kuantumContext()) {
                var aux = await context.Documents.Where(x => x.Name == name).ToListAsync();
                return new JsonResult(aux);
            }
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<JsonResult> GetByEmailAsync(string email) {
            using (var context = new kuantumContext()) {
                var aux = await context.Documents.Where(x => x.AuthorEmail == email).ToListAsync();
                return new JsonResult(aux);
            }
        }

        [HttpGet("GetByIdNameEmail/{id},{name},{email}")]
        public async Task<JsonResult> GetByIdNameEmailAsync(int id, string name, string email) {
            using (var context = new kuantumContext()) {
                var aux = context.Documents.Where(x => x.Id == id).Where(z => z.Name == name).Where(y => y.AuthorEmail == email).ToArrayAsync();
                return new JsonResult(aux);
            }
        }

    }
}
