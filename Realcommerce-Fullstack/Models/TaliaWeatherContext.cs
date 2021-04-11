using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Realcommerce_Fullstack.Models
{
	public partial  class TaliaWeatherContext : DbContext
	{
		public TaliaWeatherContext(DbContextOptions<TaliaWeatherContext> options)
			: base(options)
		{
		}
		public DbSet<Favorite> Favorites { get; set; }
		public DbSet<CityWeather> CityWeathers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Favorite>().ToTable("Favorite");
			modelBuilder.Entity<CityWeather>().ToTable("CityWeather");
		}
	}
}
