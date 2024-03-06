using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> _logger)
    {
        this._logger = _logger;
    }

    [HttpGet("{userId}")]
    public IActionResult GetUser(string userId)
    {
        // Log the user ID making the request
        _logger.LogInformation("Processing request from {User}", userId);

        // Your logic to retrieve the user information
        var user = new { Name = "John Doe", Id = userId }; // Dummy user data

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
