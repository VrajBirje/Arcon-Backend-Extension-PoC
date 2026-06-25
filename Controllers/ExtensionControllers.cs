using ArconBackend.Models;
using ArconBackend.Policies;
using ArconBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArconBackend.Controllers
{
    [ApiController]
    [Route("api/extensions")]
    public class ExtensionsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Receive(
            [FromBody] ExtensionEvent request)
        {
            string extensionId = "";
            string extensionName = "";

            if (request.Extension.ValueKind !=
                System.Text.Json.JsonValueKind.Undefined)
            {
                if (request.Extension.TryGetProperty(
                    "id",
                    out var id))
                {
                    extensionId = id.GetString();
                }

                if (request.Extension.TryGetProperty(
                    "name",
                    out var name))
                {
                    extensionName = name.GetString();
                }
            }

            bool allowed =
                ExtensionPolicy.IsAllowed(extensionId);

            var response =
                new ExtensionValidationResponse
                {
                    Allowed = allowed,

                    ExtensionId = extensionId,

                    ExtensionName = extensionName,

                    Message = allowed
                        ? "Extension Approved"
                        : "Extension Not Approved"
                };

            Console.WriteLine(
                "====================================");

            Console.WriteLine(
                $"Name     : {extensionName}");

            Console.WriteLine(
                $"ID       : {extensionId}");

            Console.WriteLine(
                $"Allowed  : {allowed}");

            Console.WriteLine(
                "====================================");

            return Ok(response);
        }
        [HttpPost("violation")]
        public IActionResult CreateViolation(
    [FromBody]
    ExtensionViolation violation)
        {
            ViolationService
                .AddViolation(
                    violation);

            Console.WriteLine(
                "\n================================");

            Console.WriteLine(
                "EXTENSION VIOLATION");

            Console.WriteLine(
                $"Name : {violation.ExtensionName}");

            Console.WriteLine(
                $"ID   : {violation.ExtensionId}");

            Console.WriteLine(
                $"Time : {violation.Timestamp}");

            Console.WriteLine(
                "================================");

            return Ok();
        }
        [HttpGet("violations")]
        public IActionResult GetViolations()
        {
            return Ok(
                ViolationService
                    .GetViolations());
        }
    }

}