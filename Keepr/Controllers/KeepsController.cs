using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        keepData.CreatorId = userInfo.Id;
        Keep newKeep = _ks.Create(keepData);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    [HttpGet]
    public ActionResult<List<Keep>> GetAll()
    {
      try
      {
        List<Keep> keeps = _ks.GetAll();
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
        Keep keep = _ks.GetById(id);
        return Ok(keep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep updateData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updateData.Id = id;
        Keep upVault = _ks.Update(updateData, userInfo.Id);
        upVault.Creator = userInfo;
        return Ok(upVault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _ks.Delete(id, userInfo.Id);
        return Ok("she gone");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}