using Microsoft.AspNetCore.Mvc;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paas.Pioneer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : AbpController
    {
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("SuitableAsync")]
        public async Task<bool> SuitableAsync()
        {
            await Task.CompletedTask;
            return Random.Shared.Next(-20, 55) >= 20;
        }

        [HttpGet("Empty")]
        public void Empty()
        {
            throw new BusinessException("已经存在该表");
        }

        [HttpGet("EmptyTask")]
        public Task EmptyTask()
        {
            var a = "213f";
            int.Parse(a);
            return Task.CompletedTask;
        }

        [HttpGet("EmptyTaskResponseOutput")]
        public IResponseOutput EmptyTaskResponseOutput()
        {
            return ResponseOutput.Succees();
        }

        [HttpGet("EmptyObj")]
        public object EmptyObj()
        {
            return new
            {
                id = 10,
                name = "dd"
            };
        }
    }
}
