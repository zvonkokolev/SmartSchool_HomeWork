using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Linq;

namespace SmartSchool.Persistence
{
	public class SensorRepository : ISensorRepository
	{
		private readonly ApplicationDbContext _dbContext;
		public SensorRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public (Sensor Sensor, double Value)[] GetSensorsWithAverageValues() => _dbContext
			.Sensors
			.Select(s => new { Sensor = s, Value = s.Measurements.Average(m => m.Value) })
			.AsEnumerable()
			.OrderBy(s => s.Sensor.Location)
			.Select(s => (s.Sensor, s.Value))
			.ToArray();
		public void Insert(Sensor sensor)
		{
			_dbContext.Sensors.Add(sensor);
		}
		public void Remove(Sensor sensor)
		{
			_dbContext.Sensors.Remove(sensor);
		}
		public void Update(Sensor sensor)
		{
			_dbContext.Sensors.Update(sensor);
		}
	}
}