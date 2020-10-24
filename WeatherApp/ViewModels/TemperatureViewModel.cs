using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
         
        //public TemperatureService: 

        /*public SetTemperatureService(/*ITemperatureService)
        {
            return 0;
        }*/

        public double CelsiusInFahrenheit(double tempC)
        {
            double tempF = Math.Round(tempC * 9 / 5 + 32, 1);
            return tempF;
        }

        public double FahrenheitInCelsius(double tempF)
        {
            double tempC = Math.Round((tempF - 32) * 5 / 9, 1);
            return tempC;
        }

        /*public SetTemperatureService(/*ITemperatureService)
        {

        }*/

        public bool CanGetTemperature()
        {
            return false;
        }
    }
}
