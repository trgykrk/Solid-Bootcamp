using Hafta2Odev.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hafta2Odev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>
        {
             new Customer
                {
                       Id = 1,
                       Code = "T1",
                       Name = "TURGAY",
                       Surname = "KARAKOÇ",
                       Age = 25
                },
              new Customer
                {
                       Id = 2,
                       Code = "M2",
                       Name = "Murat",
                       Surname = "KARAKOÇ",
                       Age = 30
                },
               new Customer
                {
                       Id = 3,
                       Code = "Ö2",
                       Name = "ÖMER",
                       Surname = "BULUT",
                       Age = 30
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = customers.Find(x => x.Id == id);
            if (customer == null)
                return BadRequest("Müşteri Bulunamadı.");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> Add(Customer customer)
        {
            customers.Add(customer);
            return Ok(customers);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> Update(Customer request)
        {
            var customer = customers.Find(x => x.Id == request.Id);
            if (customer == null)
                return BadRequest("Müşteri Bulunamadı.");
            customer.Code = request.Code; 
            customer.Name = request.Name; 
            customer.Surname = request.Surname; 
            customer.Age = request.Age; 

            return Ok(customers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var customer = customers.Find(x => x.Id == id);
            if (customer == null)
                return BadRequest("Müşteri Bulunamadı.");
            customers.Remove(customer);
            return Ok(customer);
        }
    }
}
