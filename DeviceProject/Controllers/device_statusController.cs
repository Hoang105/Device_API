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
    public class device_statusController : ControllerBase
    {
        private readonly device_managerContext _context;

        public device_statusController(device_managerContext context)
        {
            _context = context;
        }

        // GET: api/device_status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<device_status>>> Getdevice_statuses()
        {
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Ok",
                Data = await _context.device_statuses.ToListAsync()
            });
        }

        // GET: api/device_status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<device_status>> Getdevice_status(int id)
        {
            var device_status = await _context.device_statuses.FindAsync(id);

            if (device_status == null)
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
                Message = "Ok",
                Data = device_status
            });
        }

        // PUT: api/device_status/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdevice_status(int id, device_status device_status)
        {
            if (id != device_status.status_id)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "không tìm thấy id",
                    Data = BadRequest()
                });
            }

            _context.Entry(device_status).State = EntityState.Modified;

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
                if (!device_statusExists(id))
                {
                    return new OkObjectResult(new
                    {
                        Success = false,
                        Message = "không tìm thấy id",
                        Data = NotFound()
                    });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/device_status
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<device_status>> Postdevice_status(device_status device_status)
        {
            _context.device_statuses.Add(device_status);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Tạo dữ liệu thành công",
                Data = CreatedAtAction("Getdevice_status", new { id = device_status.status_id }, device_status)
            });
        }

        // DELETE: api/device_status/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<device_status>> Deletedevice_status(int id)
        {
            var device_status = await _context.device_statuses.FindAsync(id);
            if (device_status == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "false",
                    Data = NotFound()
                });
            }

            _context.device_statuses.Remove(device_status);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Success = true,
                Message = "Xóa dữ liệu thành công",
                Data = device_status
            });
        }

        private bool device_statusExists(int id)
        {
            return _context.device_statuses.Any(e => e.status_id == id);
        }
    }
}
