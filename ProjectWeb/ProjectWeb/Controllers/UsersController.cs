﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectWeb.Context;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly SubscriptionContext _context;

		public UsersController(SubscriptionContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var users = _context.Users.ToList();
				if (users.Count == 0)
				{
					return NotFound("Users List is Empty");
				}
				return Ok(users);
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var user = _context.Users.Find(id);
				if (user == null)
				{
					return NotFound("Data Not Found");
				}
				return Ok(user);
			}
			catch (Exception e)
			{

				return BadRequest(e);
			}
		}
		[HttpPost]
		public IActionResult Post(User model)
		{
			try
			{
				_context.Users.Add(model);
				_context.SaveChanges();
				return Ok("Data Added Successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpPut]
		public IActionResult Put(User model)
		{
			if (model == null || model.UserId == 0)
			{
				if (model == null)
				{
					return BadRequest("Model data is invalid");
				}
				else if (model.UserId == 0)
				{
					return BadRequest($"User {model.UserId} is invalid");
				}
			}
			try
			{
				var user = _context.Users.Find(model.UserId);
				if (user == null)
				{
					return NotFound("Data Not Found");
				}
				user.FirstName = model.FirstName;
				user.LastName = model.LastName;
				user.PhoneNumber = model.PhoneNumber;
				user.Email = model.Email;
				user.Password = model.Password;
				_context.SaveChanges();
				return Ok("User Data Updated");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			try
			{
				var user = _context.Users.Find(id);
				if (user == null)
				{
					return NotFound("User not found");
				}
				_context.Users.Remove(user);
				_context.SaveChanges();
				return Ok("User Data deleted successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[Route("Count")]
		[HttpGet]
		public IActionResult Count()
		{
			try
			{
				var users = _context.Users.ToList();
				if (users.Count == 0)
				{
					return NotFound("Users List is Empty");
				}
				return Ok(users.Count());
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpPost("authenticate")]
		public IActionResult Authenticate(User model)
		{
			if (model == null)
				return BadRequest();
			var user = _context.Users.FirstOrDefault(a => a.Email == model.Email && a.Password==model.Password);

			if (user == null)
				return NotFound(new {Message="User Not Found!"});

			model.Token = CreateJwt(user);
			return Ok(new
			{
				Token = model.Token,
				Message = "Login Successful"
			}) ;
		}

		private string CreateJwt(User model)
		{
			var jwtTokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("veryverysecrete.....");
			var identity = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name,$"{model.FirstName} {model.LastName}")
			});
			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = identity,
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = credentials
			};
			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
			return jwtTokenHandler.WriteToken(token);
		}

	}
}
