using SmartSchool.Core.Entities;
using System.Collections.Generic;

namespace SmartSchool.Core.Contracts
{
	public interface IMeasurementRepository
	{
		void AddRange(Measurement[] measurements);
		double GetAllMeasurementsCO2(Sensor sensor);
		Measurement[] GetFirstThree(Sensor sensor);
		int GetMeaurementsCounter(Sensor sensor);
	}
}
