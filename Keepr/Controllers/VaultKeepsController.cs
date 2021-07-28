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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.CreatorId = userInfo.Id;
        VaultKeep newVaultKeep = _vks.Create(vaultData);
        return Ok(newVaultKeep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<VaultKeepViewModel> GetById(int id)
    {
      try
      {
        Keep keep = _vks.GetById(id);
        return Ok(keep);
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
        _vks.Delete(id, userInfo.Id);
        return Ok("she gone");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}