using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Models;
using ProjectWeb.Context;

namespace ProjectWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserSubscriptionsController : ControllerBase
	{
		private readonly SubscriptionContext _context;
		public UserSubscriptionsController(SubscriptionContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var subscribes = _context.UserSubscriptions.ToList();
				if (subscribes.Count == 0)
				{
					return NotFound("UserSubscriptions List is Empty");
				}
				return Ok(subscribes);
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
				var subscribe = _context.UserSubscriptions.Find(id);
				if (subscribe == null)
				{
					return NotFound("Data Not Found");
				}
				return Ok(subscribe);
			}
			catch (Exception e)
			{

				return BadRequest(e);
			}
		}
		[HttpPost]
		public IActionResult Post(UserSubscription model)
		{
			try
			{
				_context.UserSubscriptions.Add(model);
				_context.SaveChanges();
				return Ok("Data Added Successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpPut]
		public IActionResult Put(UserSubscription model)
		{
			if (model == null || model.SubscriptionTierId == 0)
			{
				if (model == null)
				{
					return BadRequest("Model data is invalid");
				}
				else if (model.UserId == 0)
				{
					return BadRequest($"UserSubscriptions {model.SubscriptionTierId} is invalid");
				}
			}
			try
			{
				var subscribe = _context.UserSubscriptions.Find(model.SubscriptionTierId);
				if (subscribe == null)
				{
					return NotFound("Data Not Found");
				}
				subscribe.UserId = model.UserId;
				subscribe.SubscriptionTierId = model.SubscriptionTierId;
				subscribe.SubscriptionDate = model.SubscriptionDate;
				subscribe.SubscriptionEndDate = model.SubscriptionEndDate;
				_context.SaveChanges();
				return Ok("UserSubscriptions Data Updated");
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
				var subscribe = _context.UserSubscriptions.Find(id);
				if (subscribe == null)
				{
					return NotFound("UserSubscriptions not found");
				}
				_context.UserSubscriptions.Remove(subscribe);
				_context.SaveChanges();
				return Ok("UserSubscriptions Data deleted successfully");
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
				var subscribes = _context.UserSubscriptions.ToList();
				if (subscribes.Count == 0)
				{
					return NotFound("UserSubscriptions List is Empty");
				}
				return Ok(subscribes.Count());
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
	}
}
