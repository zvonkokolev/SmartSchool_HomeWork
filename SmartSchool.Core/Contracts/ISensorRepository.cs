using SmartSchool.Core.Entities;
using System;

namespace SmartSchool.Core.Contracts
{
	public interface ISensorRepository
	{
		void Insert(Sensor sensor);
		void Update(Sensor sensor);
		void Remove(Sensor sensor);
		(Sensor Sensor, Double Value)[] GetSensorsWithAverageValues();
	}
}
