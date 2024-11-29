using System.Collections;
using System.Net;
using System.Text;
using DnDConsole;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RollAPI.Models.DTOs;

namespace RollAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RollController : ControllerBase
{
    private IList<Roll> _rolls = new List<Roll>()
    {
        new Roll(1, new Dictionary<int, int>
        {
            { 4, 2 },
            { 8, 1 },
            { 10, 0 },
            { 12, 0 },
            { 20, 0 },
            { 100, 0 }
        }),
        
        new Roll(2, new Dictionary<int, int>
        {
            { 4, 0 },
            { 8, 3 },
            { 10, 0 },
            { 12, 0 },
            { 20, 0 },
            { 100, 0 }
        }),
        
        new Roll(3, new Dictionary<int, int>
        {
            { 4, 0 },
            { 8, 0 },
            { 10, 0 },
            { 12, 0 },
            { 20, 1 },
            { 100, 0 }
        })
    };
    
    [HttpGet]
    public ActionResult<List<RollResponseDto>> GetAllRolls()
    {
        List<RollResponseDto> rollList = new List<RollResponseDto>();
        foreach (Roll r in _rolls)
        {
            rollList.Add(new RollResponseDto(r));
        }
        return Ok(rollList);
    }

    [HttpGet("{id}")]
    public ActionResult<RollResponseDto> GetRoll(int id)
    {
        var roll = _rolls.FirstOrDefault(r => r.Id == id);
        if (roll == null)
        {
            throw new HttpRequestException(message: "Not Found", inner: null, statusCode: HttpStatusCode.NotFound);
        }

        return Ok(new RollResponseDto(roll));
    }
    
    [HttpPost]
    public ActionResult<RollResponseDto> PostRoll([FromBody] RollRequestDto req)
    {
        return Ok(new RollResponseDto(req));
    }
}

