using Microsoft.AspNetCore.Mvc;
using Exercises.Utils;
using System.Text.RegularExpressions;

namespace Exercises.Controllers;

[ApiController]
[Route("[controller]")]
public class ConvertStringToNumberController : ControllerBase
{
    private readonly ILogger<ConvertStringToNumberController> _logger;

    public ConvertStringToNumberController(ILogger<ConvertStringToNumberController> logger)
    {
        _logger = logger;
    }

    [HttpPost("{input}", Name = "GetNumberFromString")]
    public JsonResult Post(string input)
    {   
        // validation
        if(input.Length > 0)
        {
        // check if input is number
        Boolean isNumber =  Regex.IsMatch(input , @"^[+-]?\d+$");
        if (!isNumber){
            Response.StatusCode = StatusCodes.Status400BadRequest;
            return new JsonResult(new { error = "Invalid number"});
        } else {
            // check if there is sign without number
            if((input[0] == '-' || input[0] == '+') && input.Length == 1){
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new JsonResult(new { error = "Invalid number"});
            }

            StringAsNumber str = new StringAsNumber(input);
            var val = str.ConvertToNumber();
            Response.StatusCode = StatusCodes.Status200OK;
            return new JsonResult(new { value = val});
        }
    } else {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        return new JsonResult(new { error = "Input should not be empty"});
    }
    }
}