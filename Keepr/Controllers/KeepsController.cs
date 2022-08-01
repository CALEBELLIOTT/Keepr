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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> CreateKeepAsync([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Keep keep = _ks.CreateKeep(keepData, userInfo);
        return Ok(keep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet]
    public ActionResult<List<Keep>> Get()
    {
      try
      {
        List<Keep> keeps = _ks.Get();
        return keeps;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        Keep keep = _ks.Get(id);
        return keep;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> EditAsync(int id, [FromBody] Keep updated)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Keep edited = _ks.Edit(id, userInfo, updated);
        return edited;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/view")]
    public async Task<ActionResult<Keep>> ViewIncrement(int id, [FromBody] Keep updated)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Keep edited = _ks.ViewIncrement(id, userInfo, updated);
        return edited;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/keep")]
    public async Task<ActionResult<Keep>> KeepIncrement(int id, [FromBody] Keep updated)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Keep edited = _ks.KeepIncrement(id, userInfo, updated);
        return edited;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteKeepAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return _ks.DeleteKeep(id, userInfo);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }


}