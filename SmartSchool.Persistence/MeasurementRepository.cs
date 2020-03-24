using Microsoft.EntityFrameworkCore;
using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Linq;

namespace SmartSchool.Persistence
{
	public class MeasurementRepository : IMeasurementRepository
	{
		private ApplicationDbContext _dbContext;
		public MeasurementRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void AddRange(Measurement[] measurements)
		{
			_dbContext.Measurements.AddRange(measurements);
		}
		public double GetAllMeasurementsCO2(Sensor sensor) => _dbContext.Measurements
			.Include(s => s.Sensor)
			.Where(s => s.Value > 300 && s.Value < 5000 && s.Sensor.Location.Equals(sensor.Location) && s.Sensor.Name.Equals(sensor.Name))
			.Average(s => s.Value);
		public Measurement[] GetFirstThree(Sensor sensor) => _dbContext.Measurements
			.Include(s => s.Sensor)
			.Where(s => s.Sensor.Location.Equals(sensor.Location) && s.Sensor.Name.Equals(sensor.Name))
			.OrderByDescending(s => s.Value)
			.ThenByDescending(s => s.Time)
			.Take(3)
			.ToArray()
			;
		public int GetMeaurementsCounter(Sensor sensor) => _dbContext.Measurements
				.Include(s => s.Sensor)
				.Where(s => s.Sensor.Location.Equals(sensor.Location) && s.Sensor.Name.Equals(sensor.Name))
				.ToArray()
				.Count()
				;
	}
}