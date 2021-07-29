using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly KeepsService _keepsService;
    private readonly VaultsService _vaultsService;

    public ProfilesController(AccountService accountService, KeepsService keepsService, VaultsService vaultsService)
    {
      _accountService = accountService;
      _keepsService = keepsService;
      _vaultsService = vaultsService;
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfileById(string id)
    {
      try
      {
        Profile profile = _accountService.getProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/keeps")]
    public ActionResult<List<Vault>> GetKeepsByProfileId(string id)
    {
      try
      {
        List<Keep> keeps = _keepsService.GetKeepsByProfileId(id);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        if (userInfo != null)
        {
          if (id == userInfo.Id)
          {
            List<Vault> vaults = _vaultsService.GetVaultsByAccountId(id);
            return Ok(vaults);
          }
          else
          {
            List<Vault> openVaults = _vaultsService.GetVaultsByProfileId(id);
            return Ok(openVaults);
          }
        }
        else if (userInfo == null)
        {
          List<Vault> vaults = _vaultsService.GetVaultsByProfileId(id);
          return Ok(vaults);
        }
        else
        {
          return BadRequest("private");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
