using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface ITemperatureService<T>
    {
        public async Task<TemperatureModel> GetTempAsync()
        {
            TemperatureModel temp = await Task.Run(() => GetTemp());
             return temp;
        }

        private TemperatureModel GetTemp()
        {
            TemperatureModel TempReading = new TemperatureModel();

            TempReading.Temperature = 0; //TemperatureService.GetTemp();

            return TempReading;
        }
    }
}
