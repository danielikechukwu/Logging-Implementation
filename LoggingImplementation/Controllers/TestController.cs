using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // A private readonly field to hold the logger instance.
        // The ILogger interface allows logging at various levels (Information, Warning, Error, etc.).
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            // Constructor dependency injection to provide an ILogger instance specific to the TestController.
            // ASP.NET Core automatically injects the appropriate logger.

            // Assigns the injected logger to the private field.
            _logger = logger;

            // Logs an informational message when the controller instance is created. 
            // Useful for confirming that the controller is up and running.
            _logger.LogInformation("TestController Started");
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Logs an informational message indicating that the "Get" method is being executed. 
            // Helps in tracing the request flow through the application.
            _logger.LogInformation($"Executing TestController.Get Method");

            return Ok();

        }
    }
}
