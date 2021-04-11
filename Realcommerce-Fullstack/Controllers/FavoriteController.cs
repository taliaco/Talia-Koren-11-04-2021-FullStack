using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Realcommerce_Fullstack.Models;

namespace Realcommerce_Fullstack.Controllers
{
	[Route("api/Favorite")]
	public class FavoriteController : Controller
	{
		private readonly TaliaWeatherContext _context;
		private readonly IHostingEnvironment hostEnvironment;
		public FavoriteController(IHostingEnvironment httpHostEnvironment, TaliaWeatherContext weatherContext)
		{
			hostEnvironment = httpHostEnvironment;
			_context = weatherContext;
		}




		[HttpGet]
		[Route("GetFavoriteItems")]
		public ActionResult<IEnumerable<Favorite>> GetFavoriteItems()
		{
			return _context.Favorites.ToList();
		}

		[HttpGet]
		[Route("GetFavoriteItem")]
		public ActionResult<Favorite> GetFavoriteItem(string key)
		{
			var favorite = _context.Favorites.Find(key);

			if (favorite == null)
			{
				return NotFound();
			}

			return favorite;
		}

		[HttpPost]
		[Route("AddToFavorites")]
		public IActionResult AddToFavorites([FromBody] Favorite item)
		{
			if (item == null)
				return Ok();

			var favorite = _context.Favorites.Find(item.Key);

			if (favorite == null)
			{
				_context.Favorites.Add(item);
				_context.SaveChanges();
			}

			return CreatedAtAction(nameof(GetFavoriteItem), new { key = item.Key }, item);

		}
		[HttpPost]
		[Route("DeleteFavorite")]
		public IActionResult DeleteFavorite([FromBody] Favorite item)
		{
			if (item == null)
				return Ok();

			var favorite = _context.Favorites.Find(item.Key);
			if (favorite == null)
			{
				return NotFound();
			}
			_context.Favorites.Remove(favorite);
			_context.SaveChanges();
			return NoContent();
		}
	}
}
