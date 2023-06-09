using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Context;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscriptionTiersController : ControllerBase
	{
		private readonly SubscriptionContext _context;
		public SubscriptionTiersController(SubscriptionContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var tiers = _context.SubscriptionTiers.ToList();
				if (tiers.Count == 0)
				{
					return NotFound("SubscriptionTiers List is Empty");
				}
				return Ok(tiers);
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
				var tier = _context.SubscriptionTiers.Find(id);
				if (tier == null)
				{
					return NotFound("Data Not Found");
				}
				return Ok(tier);
			}
			catch (Exception e)
			{

				return BadRequest(e);
			}
		}
		[HttpPost]
		public IActionResult Post(SubscriptionTier model)
		{
			try
			{
				_context.SubscriptionTiers.Add(model);
				_context.SaveChanges();
				return Ok("Data Added Successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpPut]
		public IActionResult Put(SubscriptionTier model)
		{
			if (model == null || model.SubscriptionTierId == 0)
			{
				if (model == null)
				{
					return BadRequest("Model data is invalid");
				}
				else if (model.SubscriptionTierId == 0)
				{
					return BadRequest($"User {model.SubscriptionTierId} is invalid");
				}
			}
			try
			{
				var tier = _context.SubscriptionTiers.Find(model.SubscriptionTierId);
				if (tier == null)
				{
					return NotFound("Data Not Found");
				}
				tier.TierName = model.TierName;
				tier.Price=model.Price;
				tier.Duration=model.Duration;
				tier.ServiceId=model.ServiceId;
				_context.SaveChanges();
				return Ok("SubscriptionTier Data Updated");
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
				var tier = _context.SubscriptionTiers.Find(id);
				if (tier == null)
				{
					return NotFound("Tier not found");
				}
				_context.SubscriptionTiers.Remove(tier);
				_context.SaveChanges();
				return Ok("SubscriptionTier Data deleted successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
	}
}
