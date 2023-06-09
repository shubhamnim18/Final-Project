﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Context;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductServicesController : ControllerBase
	{
		private readonly SubscriptionContext _context;
		public ProductServicesController(SubscriptionContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var services = _context.ProductServices.ToList();
				if (services.Count == 0)
				{
					return NotFound("Services List is Empty");
				}
				return Ok(services);
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
				var service = _context.ProductServices.Find(id);
				if (service == null)
				{
					return NotFound("Data Not Found");
				}
				return Ok(service);
			}
			catch (Exception e)
			{

				return BadRequest(e);
			}
		}
		[HttpPost]
		public IActionResult Post(ProductService model)
		{
			try
			{
				_context.ProductServices.Add(model);
				_context.SaveChanges();
				return Ok("Data Added Successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
		[HttpPut]
		public IActionResult Put(ProductService model)
		{
			if (model == null || model.ServiceId == 0)
			{
				if (model == null)
				{
					return BadRequest("Model data is invalid");
				}
				else if (model.ServiceId == 0)
				{
					return BadRequest($"Service {model.ServiceId} is invalid");
				}
			}
			try
			{
				var service = _context.ProductServices.Find(model.ServiceId);
				if (service == null)
				{
					return NotFound("Data Not Found");
				}
				service.ServiceName = model.ServiceName;
				service.Image=model.Image;
				_context.SaveChanges();
				return Ok("Service Data Updated");
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
				var service = _context.ProductServices.Find(id);
				if (service == null)
				{
					return NotFound("User not found");
				}
				_context.ProductServices.Remove(service);
				_context.SaveChanges();
				return Ok("Service Data deleted successfully");
			}
			catch (Exception e)
			{

				return BadRequest(e.Message);
			}
		}
	}
}
