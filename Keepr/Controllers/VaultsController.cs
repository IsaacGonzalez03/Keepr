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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }


    [HttpGet("{id}/keeps")]
    public async Task<ActionResult<List<VaultKeepViewModel>>> GetVaultKeeps(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault vault = _vs.GetById(id);
        List<VaultKeepViewModel> keeps = _vs.GetVaultKeeps(id);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.CreatorId = userInfo.Id;
        Vault newVault = _vs.Create(vaultData);
        newVault.Creator = userInfo;
        return Ok(newVault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetById(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault vault = _vs.GetById(id);
        return Ok(vault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }





    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault updateData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updateData.Id = id;
        Vault upVault = _vs.Update(updateData, userInfo.Id);
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
        _vs.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}