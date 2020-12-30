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
    public class role_managerController : ControllerBase
    {
        private readonly device_managerContext _context;

        public role_managerController(device_managerContext context)
        {
            _context = context;
        }

        // GET: api/role_manager
        [HttpGet]
        public async Task<ActionResult<IEnumerable<role_manager>>> Getrole_managers()
        {
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = await _context.role_managers.ToListAsync()
            });
        }

        // GET: api/role_manager/5
        [HttpGet("{id}")]
        public async Task<ActionResult<role_manager>> Getrole_manager(int id)
        {
            var role_manager = await _context.role_managers.FindAsync(id);

            if (role_manager == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "False",
                    Data = NotFound()
                });
            }
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = role_manager
            });
        }

        // PUT: api/role_manager/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrole_manager(int id, role_manager role_manager)
        {
            if (id != role_manager.role_manager_id)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = BadRequest()
                });
            }

            _context.Entry(role_manager).State = EntityState.Modified;

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
                if (!role_managerExists(id))
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

        // POST: api/role_manager
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<role_manager>> Postrole_manager(role_manager role_manager)
        {
            _context.role_managers.Add(role_manager);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Nhập dữ liệu thành công",
                Data = CreatedAtAction("Getrole_manager", new { id = role_manager.role_manager_id }, role_manager)
            });
        }

        // DELETE: api/role_manager/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<role_manager>> Deleterole_manager(int id)
        {
            var role_manager = await _context.role_managers.FindAsync(id);
            if (role_manager == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = NotFound()
                });
            }

            _context.role_managers.Remove(role_manager);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Xóa dữ liệu thành công",
                Data = role_manager
            });
        }

        private bool role_managerExists(int id)
        {
            return _context.role_managers.Any(e => e.role_manager_id == id);
        }
    }
}
