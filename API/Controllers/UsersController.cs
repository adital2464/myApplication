﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController: ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")] // /api/useres/2
    public async Task<ActionResult<AppUser>> GetUserAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}