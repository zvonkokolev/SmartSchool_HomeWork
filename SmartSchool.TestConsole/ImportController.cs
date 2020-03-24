using System;
using Utils;
using System.Collections.Generic;
using SmartSchool.Core.Entities;
using System.Text;

namespace SmartSchool.TestConsole
{
	public static class ImportController
	{
		const string Filename = "measurements.csv";

		/// <summary>
		/// Liefert die Messwerte mit den dazugehörigen Sensoren
		/// </summary>
		public static IEnumerable<Measurement> ReadFromCsv()
		{
			Dictionary<string, Sensor> sensors = new Dictionary<string, Sensor>();
			List<Measurement> measurements = new List<Measurement>();
			string[][] csvLineParts = MyFile.ReadStringMatrixFromCsv(Filename, true);
			Sensor sensor = new Sensor();
			Measurement measurement;
			for (int i = 0; i < csvLineParts.Length; i++)
			{
				StringBuilder timeAsString = new StringBuilder();
				timeAsString.Append(csvLineParts[i][0]);
				timeAsString.Append(' ');
				timeAsString.Append(csvLineParts[i][1]);
				DateTime dateTime = Convert.ToDateTime(timeAsString.ToString());
				string[] parts = csvLineParts[i][2].Split('_');
				if (!(sensors.ContainsKey(csvLineParts[i][2])))
				{
					sensor = new Sensor { Location = parts[0], Name = parts[1] };
					sensors.Add(csvLineParts[i][2], sensor);
				}
				else
				{
					foreach (var item in sensors)
					{
						if (item.Key.Equals(csvLineParts[i][2]))
						{
							sensor = item.Value;
						}
					}
				}
				measurement = new Measurement
				{
					Sensor = sensor,
					Time = dateTime,
					Value = Convert.ToDouble(csvLineParts[i][3])
				};
				measurements.Add(measurement);
			}
			return measurements;
		}
	}
}
