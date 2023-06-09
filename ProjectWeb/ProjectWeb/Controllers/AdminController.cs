using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Context;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly SubscriptionContext _context;
		public AdminController(SubscriptionContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Get(string uname,string pass)
		{
			try
			{
				var admin = _context.Admins.Where(a=>a.UserName==uname && a.Password==pass);
				if (admin == null)
				{
					return NotFound("Data Not Found");
				}
				return Ok(admin);
			}
			catch (Exception e)
			{

				return BadRequest(e);
			}
		}
		[HttpPost]
		public IActionResult Post(Admin model)
		{
			try
			{
				_context.Admins.Add(model);
				_context.SaveChanges();
				return Ok("Data Added Successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpPut]
		public IActionResult Put(Admin model)
		{
			if (model == null || model.AdminId == 0)
			{
				if (model == null)
				{
					return BadRequest("Model data is invalid");
				}
				else if (model.AdminId == 0)
				{
					return BadRequest($"Admin {model.AdminId} is invalid");
				}
			}
			try
			{
				var admin = _context.Admins.Find(model.AdminId);
				if (admin == null)
				{
					return NotFound("Data Not Found");
				}
				admin.FirstName = model.FirstName;
				admin.LastName = model.LastName;
				admin.UserName = model.UserName;
				admin.Password = model.Password;
				_context.SaveChanges();
				return Ok("Admin Data Updated");
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
				var admin = _context.Admins.Find(id);
				if (admin == null)
				{
					return NotFound("User not found");
				}
				_context.Admins.Remove(admin);
				_context.SaveChanges();
				return Ok("Admin Data deleted successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
	}
}
