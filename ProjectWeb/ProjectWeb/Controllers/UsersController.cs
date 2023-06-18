using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using ProjectWeb.Context;
using Microsoft.EntityFrameworkCore;

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
				return Ok(new { Message="Data Added Successfully" });
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
				var data = _context.Users.FromSqlRaw("exec DELETEUSER @input={0}", id).ToList();
				_context.SaveChanges();
				return Ok(new { Message = "User Data deleted successfully" });
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
			var user = _context.Users.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);

			if (user == null)
				return NotFound(new { Message = "User Not Found!" });

			return Ok(user);
		}
	}
}
