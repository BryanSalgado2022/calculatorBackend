using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calculatorBackend.Controllers
{
    [Route("api/sum")]
    [ApiController]
    public class SumController : ControllerBase
    {

        [HttpGet]
        [Route("add")]
        public dynamic AddNumbers(int number1, int number2)
        {
            int sum;
            sum = number1 + number2;
            return sum;
        }
        
    }
}
