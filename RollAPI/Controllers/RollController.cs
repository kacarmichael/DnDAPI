﻿using System.Collections;
using System.Net;
using System.Text;
using DnDConsole;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RollAPI.DTOs;

namespace RollAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RollController : ControllerBase
{
    private IList<Roll> rolls = new List<Roll>()
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
    public ActionResult<List<RollDTO>> GetAllRolls()
    {
        List<RollDTO> rollList = new List<RollDTO>();
        foreach (Roll r in rolls)
        {
            rollList.Add(new RollDTO(r));
        }
        return Ok(rollList);
    }

    [HttpGet("{id}")]
    public ActionResult<RollDTO> GetRoll(int id)
    {
        var roll = rolls.FirstOrDefault(r => r.Id == id);
        if (roll == null)
        {
            throw new HttpRequestException(message: "Not Found", inner: null, statusCode: HttpStatusCode.NotFound);
        }

        return Ok(new RollDTO(roll));
    }
}
