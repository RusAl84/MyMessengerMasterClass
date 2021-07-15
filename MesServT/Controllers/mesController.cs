using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MesServT.MessageClass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MesServT.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class mesController : ControllerBase
  {
    static List<Message> ListOfMessages = new List<Message>();

    // GET: api/<mesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/<Mes>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      string OutputString = "Not found";
      if ((id < ListOfMessages.Count) && (id >= 0))
      {
        OutputString = JsonConvert.SerializeObject(ListOfMessages[id]);
      }
      Console.WriteLine(String.Format("Запрошено сообщение № {0} : {1}", id, OutputString));
      return OutputString;
    }

    // POST api/<Mes>
    [HttpPost]
    public IActionResult SendMessage([FromBody] Message msg)
    {
      if (msg == null)
      {
        return BadRequest();
      }
      ListOfMessages.Add(msg);
      Console.WriteLine(String.Format("Всего сообщений: {0} Посланное сообщение: {1}", ListOfMessages.Count, msg));
      //return new NoContentResult();
      return new OkResult();
    }


    //// GET api/<mesController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //  return "value";
    //}

    //// POST api/<mesController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<mesController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<mesController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
  }
}
