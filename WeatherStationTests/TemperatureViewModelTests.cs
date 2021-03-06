﻿using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xunit;
using Xunit.Sdk;

namespace WeatherStationTests
{
    public class TemperatureViewModelTests : IDisposable
    {
        // System Under Test
        // Utilisez ce membre dans les tests
        TemperatureViewModel _sut = new TemperatureViewModel();

        /// <summary>
        /// Test la fonctionnalité de conversion de Celsius à Fahrenheit
        /// </summary>
        /// <param name="C">Degré Celsius</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T01</remarks>
        [Theory]
        [InlineData(0, 32)]
        [InlineData(-40, -40)]
        [InlineData(-20, -4)]
        [InlineData(-17.8, 0)]
        [InlineData(37, 98.6)]
        [InlineData(100, 212)]
        public void CelsisInFahrenheit_AlwaysReturnGoodValue(double C, double expected)
        {
            // Arrange

            //rien ici car on a ce que ca prends en parametre

            // Act       
            //double actualF = Math.Round(C * 9/5 + 32,1);
            double actualF = TemperatureViewModel.CelsiusInFahrenheit(C); //CelsiusInFahrenheit(double tempC)

            // Assert
            Assert.Equal(expected, actualF);

            /// TODO : git commit -a -m "T01 CelsisInFahrenheit_AlwaysReturnGoodValue : Done" fait
        }

        /// <summary>
        /// Test la fonctionnalité de conversion de Fahrenheit à Celsius
        /// </summary>
        /// <param name="F">Degré F</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T02</remarks>
        [Theory]
        [InlineData(32, 0)]
        [InlineData(-40, -40)]
        [InlineData(-4, -20)]
        [InlineData(0, -17.8)]
        [InlineData(98.6, 37)]
        [InlineData(212, 100)]
        public void FahrenheitInCelsius_AlwaysReturnGoodValue(double F, double expected)
        {
            // Arrange

            //rien ici car on a ce que ca prends en parametre

            // Act       

            // double actualC = Math.Round((F - 32) * 5 / 9,1);
            double actualC = TemperatureViewModel.FahrenheitInCelsius(F);
            // Assert

            Assert.Equal(expected, actualC);

            /// TODO : git commit -a -m "T02 FahrenheitInCelsius_AlwaysReturnGoodValue : Done" fait
        }

        /// <summary>
        /// Lorsqu'exécuté GetTempCommand devrait lancer une NullException
        /// </summary>
        /// <remarks>T03</remarks>
        [Fact]
        public void GetTempCommand_ExecuteIfNullService_ShouldThrowNullException()
        {
            // Arrange
            //pas besoin

            // Act       
            //pas besoin

            // Assert

            Assert.Throws<NullReferenceException>(()=> _sut.GetTempCommand.Execute(string.Empty));

            /// TODO : git commit -a -m "T03 GetTempCommand_ExecuteIfNullService_ShouldThrowNullException : Done"
        }

        /// <summary>
        /// La méthode CanGetTemp devrait retourner faux si le service est null
        /// </summary>
        /// <remarks>T04</remarks>
        [Fact]
        public void CanGetTemp_WhenServiceIsNull_ReturnsFalse()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();
            _sut.service = null;

            // Act

            Boolean canGetTemp = _sut.GetTempCommand.CanExecute(string.Empty);
            // Assert
            Assert.False(canGetTemp);

            /// TODO : git commit -a -m "T04 CanGetTemp_WhenServiceIsNull_ReturnsFalse : Done"
        }

        /// <summary>
        /// La méthode CanGetTemp devrait retourner vrai si le service est instancié
        /// </summary>
        /// <remarks>T05</remarks>
        [Fact]
        public void CanGetTemp_WhenServiceIsSet_ReturnsTrue()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();

            var _mock = new Mock<ITemperatureService>();
           //ancien code, ca a pas rapport avec le test... on veut seulement le SetTemperature, pas plus que ca... le mur atteint au test7 me force a revoir les tests et constater mes erreurs...

            _sut.SetTemperatureService(_mock.Object);

            // Act       
            Boolean canGetTemp = _sut.GetTempCommand.CanExecute(string.Empty);

            // Assert
            Assert.True(canGetTemp);

            /// TODO : git commit -a -m "T05 CanGetTemp_WhenServiceIsSet_ReturnsTrue : Done"
        }

        /// <summary>
        /// TemperatureService ne devrait plus être null lorsque SetTemperatureService
        /// </summary>
        /// <remarks>T06</remarks>
        [Fact]
        public void SetTemperatureService_WhenExecuted_TemperatureServiceIsNotNull()
        {
            // Arrange
            TemperatureViewModel _sut = new TemperatureViewModel();
            Mock<ITemperatureService> _mock_ITemperatureService = new Mock<ITemperatureService>();

            // Act       
            _sut.SetTemperatureService(_mock_ITemperatureService.Object);

            // Assert
            Assert.NotNull(_sut.service);

            /// TODO : git commit -a -m "T06 SetTemperatureService_WhenExecuted_TemperatureServiceIsNotNull : Done"
        }

        /// <summary>
        /// CurrentTemp devrait avoir une valeur lorsque GetTempCommand est exécutée
        /// </summary>
        /// <remarks>T07</remarks>
        [Fact]
        public void GetTempCommand_HaveCurrentTempWhenExecuted_ShouldPass()
        {
            // Arrange
            Mock<ITemperatureService> _mockService = new Mock<ITemperatureService>();

            // Act       
            _mockService.Setup(x => x.GetTempAsync()).Returns(Task.FromResult(new TemperatureModel()));
            _sut.SetTemperatureService(_mockService.Object);
            _sut.GetTempCommand.Execute(string.Empty);

            // Assert
            Assert.NotNull(_sut.CurrentTemp);
            /// TODO : git commit -a -m "T07 GetTempCommand_HaveCurrentTempWhenExecuted_ShouldPass : Done"
        }

        /// <summary>
        /// Ne touchez pas à ça, c'est seulement pour respecter les standards
        /// de test qui veulent que la classe de tests implémente IDisposable
        /// Mais ça peut être utilisé, par exemple, si on a une connexion ouverte, il
        /// faut s'assurer qu'elle sera fermée lorsque l'objet sera détruit
        /// </summary>
        public void Dispose()
        {
            // Nothing to here, just for Testing standards
        }
    }
}
