using employeeManager.API.Models;
using employeeManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace employeeManager.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JsonResult))]
    public class CustomerController : Controller
    {
        private ICustomerService CustomerSvc { get; }

        public CustomerController(ICustomerService customerService)
        {
            this.CustomerSvc = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerRequest req)
        {
            if (req == null)
                return BadRequest("check request parameters");
            bool isSucess = await this.CustomerSvc.CreateNewCustomer(req);
            return Json(new { result = isSucess });
        }

       
    }
}
