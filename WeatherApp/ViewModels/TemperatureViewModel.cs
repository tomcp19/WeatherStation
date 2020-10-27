using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet


        //******************
        public ITemperatureService service;
        public DelegateCommand<string> GetTempCommand { get; set; }
        public object CurrentTemp { get; set; }

        //public TemperatureModel CurrentTemp;
        //*****************

        public TemperatureViewModel()
        {
            GetTempCommand = new DelegateCommand<string>(GetTemp, CanGetTemperature);
            CurrentTemp = new TemperatureModel();
        }

        public void SetTemperatureService(ITemperatureService _service)
        {
            ITemperatureService service = _service;
        }

        private void GetTemp(string obj)
        {
            CurrentTemp = service.GetTemp();
        }

        public static double CelsiusInFahrenheit(double tempC)
        {
            double tempF = Math.Round(tempC * 9 / 5 + 32, 1);
            return tempF;
        }

        public static double FahrenheitInCelsius(double tempF)
        {
            double tempC = Math.Round((tempF - 32) * 5 / 9, 1);
            return tempC;
        }

        public bool CanGetTemperature(string obj)
        {
            return false; //!string.IsNullOrEmpty(SelectedFolder);         
        }
    }
}
