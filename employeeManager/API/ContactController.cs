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
    public class ContactController : Controller
    {
        private ICustomerService CustomerSvc { get; }

        public ContactController(ICustomerService customerService)
        {
            this.CustomerSvc = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ContactRequest req)
        {
            if (req == null)
                return BadRequest("check request parameters");
            bool isSucess = await this.CustomerSvc.DeleteContact(req.Id);
            return Json(new { result = isSucess });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact (ContactRequest req)
        {
            if (req == null)
                return BadRequest("check request parameters");

            bool isSucess = await this.CustomerSvc.UpdateContact(req);
            if (!isSucess)
                return Json(new { result = "failed" });

            return Json(new { result = "all good" });
        }
    }
}
