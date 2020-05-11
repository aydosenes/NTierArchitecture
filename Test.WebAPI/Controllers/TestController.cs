using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;
using Test.Core.Services;

namespace Test.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUpTestService _uptestService;

        public TestController(IUpTestService testService)
        {
            _uptestService = testService;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UpTest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var test = await _uptestService.GetAllAsync();

            return Ok(test);
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UpTest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTestById(int id)
        {
            var test = await _uptestService.GetById(id);

            return Ok(test);
            
        }


        //    [HttpGet("get/{id}")]
        //    [Produces("application/json")]
        //    [ProducesResponseType(typeof(TestModel), StatusCodes.Status200OK)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //    public IActionResult GetTestById(int idno)
        //    {
        //        var result = _testService.GetMember(idno);

        //        if (result.Result.Data != null)
        //        {
        //            return Ok(result.Result.Data);
        //        }
        //        return BadRequest(result.Result.Message);
        //    }

        //    [HttpPost("add")]
        //    [Produces("application/json")]
        //    [ProducesResponseType(typeof(TestModel), StatusCodes.Status200OK)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //    public IActionResult AddTest([FromBody] TestModel model)
        //    {
        //        var result = _testService.Add(model);

        //        if (result.Result.Success)
        //        {
        //            return Ok(result.Result.Message);
        //        }
        //        return BadRequest(result.Result.Message);
        //    }

        //    [HttpPost("update")]
        //    [Produces("application/json")]
        //    [ProducesResponseType(typeof(TestModel), StatusCodes.Status200OK)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //    public IActionResult UpdateTest([FromBody] TestModel model)
        //    {
        //        var result = _testService.Update(model);

        //        if (result.Result.Success)
        //        {
        //            return Ok(result.Result.Message);
        //        }
        //        return BadRequest(result.Result.Message);
        //    }

        //    [HttpPost("delete")]
        //    [Produces("application/json")]
        //    [ProducesResponseType(typeof(TestModel), StatusCodes.Status200OK)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //    public IActionResult DeleteTest([FromBody] TestModel model)
        //    {
        //        var result = _testService.Delete(model);

        //        if (result.Result.Success)
        //        {
        //            return Ok(result.Result.Message);
        //        }
        //        return BadRequest(result.Result.Message);
        //    }
    }
}