using Microsoft.AspNetCore.Mvc;

namespace GPM.Controllers;

public class ErrorsController : ControllerBase{
    [Route("/error")]
    public IActionResult Error(){
        return Problem();
    }
}