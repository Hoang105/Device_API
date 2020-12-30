using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceProject.Models;

namespace DeviceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectsController : ControllerBase
    {
        private readonly device_managerContext _context;

        public projectsController(device_managerContext context)
        {
            _context = context;
        }

        // GET: api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<project>>> Getprojects()
        {
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = await _context.projects.ToListAsync()
            });
        }

        // GET: api/projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<project>> Getproject(int id)
        {
            var project = await _context.projects.FindAsync(id);

            if (project == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = NotFound()
                });
            }
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = project
            });
        }

        // PUT: api/projects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproject(int id, project project)
        {
            if (id != project.project_id)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = BadRequest()
                });
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                return new OkObjectResult(new
                {
                    Success = true,
                    Message = "Thay đổi dữ liệu thành công",
                    Data = await _context.SaveChangesAsync()
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectExists(id))
                {
                    return new OkObjectResult(new
                    {
                        Success = false,
                        Message = "false",
                        Data = NotFound()
                    });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/projects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<project>> Postproject(project project)
        {
            _context.projects.Add(project);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Nhập dữ liệu thành công",
                Data = CreatedAtAction("Getproject", new { id = project.project_id }, project)
            });
        }

        // DELETE: api/projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<project>> Deleteproject(int id)
        {
            var project = await _context.projects.FindAsync(id);
            if (project == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = NotFound()
                });
            }

            _context.projects.Remove(project);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Success = true,
                Message = "Xóa dữ liệu thành công",
                Data = project
            });
        }

        private bool projectExists(int id)
        {
            return _context.projects.Any(e => e.project_id == id);
        }
    }
}
