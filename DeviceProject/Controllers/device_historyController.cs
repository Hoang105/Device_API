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
    public class device_historyController : ControllerBase
    {
        private readonly device_managerContext _context;

        public device_historyController(device_managerContext context)
        {
            _context = context;
        }

        // GET: api/device_history
        [HttpGet]
        public async Task<ActionResult<IEnumerable<device_history>>> Getdevice_histories()
        {
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Ok",
                Data = await _context.device_histories.ToListAsync()
            });
        }

        // GET: api/device_history/5
        [HttpGet("{id}")]
        public async Task<ActionResult<device_history>> Getdevice_history(int id)
        {
            var device_history = await _context.device_histories.FindAsync(id);

            if (device_history == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "Ok",
                    Data = NotFound()
                });
            }
            return new OkObjectResult(new
            {
                Success = true,
                Message = "Ok",
                Data = device_history
            });
        }

        // PUT: api/device_history/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdevice_history(int id, device_history device_history)
        {
            if (id != device_history.device_history_id)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "Ok",
                    Data = BadRequest()
                });
            }

            _context.Entry(device_history).State = EntityState.Modified;

            try
            {
                return new OkObjectResult(new
                {
                    Success = true,
                    Message = "Ok",
                    Data = _context.SaveChangesAsync()
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!device_historyExists(id))
                {
                    return new OkObjectResult(new
                    {
                        Success = false,
                        Message = "Ok",
                        Data = NotFound()
                    });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/device_history
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<device_history>> Postdevice_history(device_history device_history)
        {
            _context.device_histories.Add(device_history);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Success = true,
                Message = "Ok",
                Data = CreatedAtAction("Getdevice_history", new { id = device_history.device_history_id }, device_history)
            });
        }

        // DELETE: api/device_history/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<device_history>> Deletedevice_history(int id)
        {
            var device_history = await _context.device_histories.FindAsync(id);
            if (device_history == null)
            {
                return new OkObjectResult(new
                {
                    Success = false,
                    Message = "Ok",
                    Data = NotFound()
                });
            }

            _context.device_histories.Remove(device_history);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Success = false,
                Message = "Ok",
                Data = device_history
            });
        }
        [Route("getfilterhistory")]
        [HttpPost]
        public async Task<IActionResult> GetByFilter(device_history_filter filter)
        {
                var Data = await _context.device_histories.Where(x =>
                (
                    (filter.device_change_id <= 0 || x.device_change_id == filter.device_change_id))).ToArrayAsync();
                return new OkObjectResult(new
                {
                    Success = true,
                    Message = "Ok",
                    Data = Data
                });
        }
        private bool device_historyExists(int id)
        {
            return _context.device_histories.Any(e => e.device_history_id == id);
        }
    }
}
