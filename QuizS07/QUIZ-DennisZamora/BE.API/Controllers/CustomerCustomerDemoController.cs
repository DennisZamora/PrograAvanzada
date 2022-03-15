using BE.DAL.DO.Objects;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCustomerDemoController : Controller
    {
        private readonly NDbContext _context;
        public CustomerCustomerDemoController(NDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCustomerDemoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCustomerDemo>>> GetCustomerCustomerDemo()
        {
            return new BE.BS.CustomerCustomerDemo(_context).GetAll().ToList();
        }

        // GET: api/CustomerCustomerDemoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCustomerDemo>> GetCustomerCustomerDemo(string id)
        {
            var customerCustomerDemo = new BE.BS.CustomerCustomerDemo(_context).GetOneById(id);

            if (customerCustomerDemo == null)
            {
                return NotFound();
            }

            return customerCustomerDemo;
        }

        // PUT: api/CustomerCustomerDemoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCustomerDemo(string id, CustomerCustomerDemo customerCustomerDemo)
        {
            if (id != customerCustomerDemo.CustomerId)
            {
                return BadRequest();
            }


            try
            {
                new BE.BS.CustomerCustomerDemo(_context).Update(customerCustomerDemo);
            }
            catch (Exception)
            {
                if (!CustomerCustomerDemoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerCustomerDemoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerCustomerDemo>> PostCustomerCustomerDemo(CustomerCustomerDemo customerCustomerDemo)
        {
            try
            {
                new BE.BS.CustomerCustomerDemo(_context).Insert(customerCustomerDemo);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCustomerCustomerDemo", new { id = customerCustomerDemo.CustomerId }, customerCustomerDemo);
        }

        // DELETE: api/CustomerCustomerDemoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerCustomerDemo>> DeleteCustomerCustomerDemo(string id)
        {
            var customerCustomerDemo = new BE.BS.CustomerCustomerDemo(_context).GetOneById(id);
            if (customerCustomerDemo == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.CustomerCustomerDemo(_context).Delete(customerCustomerDemo);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return customerCustomerDemo;
        }


        private bool CustomerCustomerDemoExists(string id)
        {
            return (new BE.BS.CustomerCustomerDemo(_context).GetOneById(id) != null);
        }



    }
}
