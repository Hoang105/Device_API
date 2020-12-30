using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceProject.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Web.Http.Results;

namespace DeviceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class user_managerController : ControllerBase
    {
        private readonly device_managerContext _context;

        public user_managerController(device_managerContext context)
        {
            _context = context;
        }

        // GET: api/user_manager
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user_manager>>> Getuser_managers()
        {
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = await _context.user_managers.ToListAsync()
            });
        }

        // GET: api/user_manager/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user_manager>> Getuser_manager(int id)
        {
            var user_manager = await _context.user_managers.FindAsync(id);

            if (user_manager == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "Không có mã nhân viên nào",
                    Data = NotFound()
                });
            }
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = user_manager
            });
        }

        // PUT: api/user_manager/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser_manager(int id, user_manager user_manager)
        {
            if (id != user_manager.user_manager_id)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "Not found id",
                    Data = BadRequest()
                });
            }

            _context.Entry(user_manager).State = EntityState.Modified;

            try
            {
                return new OkObjectResult(new
                {
                    Success = true,
                    Message = "Thay đổi thành công",
                    Data = await _context.SaveChangesAsync()
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_managerExists(id))
                {
                    return new OkObjectResult(new
                    {
                        Success = false,
                        Message = "Not found id",
                        Data = NotFound()
                    });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/user_manager
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<user_manager>> Postuser_manager(user_manager user_manager)
        {
            _context.user_managers.Add(user_manager);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Success = true,
                Message = "Success",
                Data = CreatedAtAction("Getuser_manager", new { id = user_manager.user_manager_id }, user_manager)
            });
        }

        // DELETE: api/user_manager/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<user_manager>> Deleteuser_manager(int id)
        {
            var user_manager = await _context.user_managers.FindAsync(id);
            if (user_manager == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = NotFound()
                });
            }

            _context.user_managers.Remove(user_manager);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Đã xóa thành công",
                Data = user_manager
            });
        }

        private bool user_managerExists(int id)
        {
            return _context.user_managers.Any(e => e.user_manager_id == id);
        }
    }
}
