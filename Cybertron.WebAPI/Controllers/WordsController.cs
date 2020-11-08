using Microsoft.AspNetCore.Mvc;
using Cybertron.Core.Interfaces.Commands;
using System.Threading.Tasks;

namespace Cybertron.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        [HttpGet]
        public Task<string[]> Get([FromServices] IGetAllWords command)
        {
            return command.Activate();
        }

        [HttpGet("{word}")]
        public Task<string> Get(string word, [FromServices] IGetWordByName command)
        {
            return command.Activate(word);
        }

        [HttpGet("random")]
        public Task<string> Get([FromServices] IGetRandomWord command)
        {
            return command.Activate();
        }
    }
}
