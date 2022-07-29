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


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault vault = _vs.CreateVault(userInfo, vaultData);
        return vault;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Vault vault = _vs.Get(id, userInfo);
        return Ok(vault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> EditVaultAsync(int id, [FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.Id = id;
        Vault editedVault = _vs.EditVault(id, userInfo, vaultData);
        return editedVault;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteVaultAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _vs.DeleteVault(id, userInfo);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}