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
            if (req == null || string.IsNullOrEmpty(req.CustomerNumber) || string.IsNullOrEmpty(req.Name))
                return BadRequest("check request parameters");
            bool isSucess = await this.CustomerSvc.CreateNewCustomer(req);
            return Json(new { result = isSucess });
        }

        [HttpPost]
        public async Task<IActionResult> IsCustomerExist(CustomerRequest req)
        {
            if (req == null || string.IsNullOrEmpty(req.CustomerNumber))
                return BadRequest("check request parameters");

            bool isExist = await this.CustomerSvc.IsCustomerExist(req.CustomerNumber);
            return Json(new { result = isExist });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(CustomerRequest req)
        {
            if (req == null)
                return BadRequest("check request parameters");
            bool isSucess = await this.CustomerSvc.DeleteCustomer(req.Id);
            return Json(new { result = isSucess });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest req)
        {
            if (req == null)
                return BadRequest("check request parameters");

            bool isSucess = await this.CustomerSvc.UpdateCustomer(req);
            if (!isSucess)
                return Json(new { result = "failed" });

            return Json(new { result = "all good" });
        }


    }
}
