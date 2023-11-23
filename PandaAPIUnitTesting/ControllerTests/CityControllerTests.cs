using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;
using PandaAPI.Controllers;
using PandaApplication.Services;
using PandaApplication.Services.Interfaces;
using PandaDomain.Entities;
using PandaDomain.Mappings;
using PandaDomain.Models.Request;
using PandaDomain.Models.Response;
using System.Net;

namespace PandaAPIUnitTesting.ControllerTests
{
    public class CityControllerTests
    {
        private readonly Mock<ICityService> _cityService;
        private CityController _controller;

        public CityControllerTests()
        {
            _cityService = new Mock<ICityService>();
            _controller = new CityController(_cityService.Object);
        }

        [Fact]
        public async void GetListCity_ReturnsListOfCities()
        {
            // Arrange
            var expectedCities = GetSampleCityList();
            _cityService.Setup(x => x.GetListCity()).ReturnsAsync(expectedCities);

            // Act
            var result = await _controller.GetListCity();

            // Assert
            Assert.NotNull(result);

            var okResult = Assert.IsType<ActionResult<List<CityResponse>>>(result);
            var actualCities = Assert.IsType<OkObjectResult>(okResult.Result).Value;

            // Add more specific assertions based on your requirements
            Assert.IsType<List<CityResponse>>(actualCities);
            Assert.Equal(expectedCities.Count, (actualCities as List<CityResponse>).Count);
        }

        [Fact]
        public async void AddCity_ReturnsOkResultWithListOfCities()
        {
            // Arrange
            var cityRequest = new AddCityRequest
            {
                CityName = "City3"
            };

            var expectedCities = GetSampleCityList().Append(new CityResponse
            {
                CityId = 3,
                CityName = "City3"
            }).ToList();

            _cityService.Setup(x => x.AddCity(cityRequest)).ReturnsAsync(expectedCities);

            // Act
            var result = await _controller.AddCity(cityRequest);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<ActionResult<List<CityResponse>>>(result);
            var actualCitiesResponse = Assert.IsType<OkObjectResult>(okResult.Result).Value;

            // Add more specific assertions based on your requirements
            Assert.IsType<List<CityResponse>>(actualCitiesResponse);
            Assert.Equal(expectedCities, actualCitiesResponse as List<CityResponse>);
        }

        [Fact]
        public async void UpdateCity_ReturnsOkResultWithCityResponse()
        {
            // Arrange
            var cityRequest = new UpdateCityRequest
            {
                CityId = 1,
                CityName = "City One"
            };

            var expectedCity = new CityResponse
            {
                CityId = 1,
                CityName = "City One"
            };

            _cityService.Setup(x => x.UpdateCity(cityRequest)).ReturnsAsync(expectedCity);

            // Act
            var result = await _controller.UpdateCity(cityRequest);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<ActionResult<CityResponse>>(result);
            var actualCityResponse = Assert.IsType<OkObjectResult>(okResult.Result).Value;

            // Add more specific assertions based on your requirements
            Assert.IsType<CityResponse>(actualCityResponse);
            Assert.Equal(expectedCity.CityId, (actualCityResponse as CityResponse).CityId);
            Assert.Equal(expectedCity.CityName, (actualCityResponse as CityResponse).CityName);
        }

        [Fact]
        public async void DeleteCity_ReturnsOkResultWithListOfCities()
        {
            int cityId = 1;
            // Arrange
            var sampleCityList = GetSampleCityList();
            var expectedCities = sampleCityList.Where(city => city.CityId != 1).ToList();

            _cityService.Setup(x => x.Delete(cityId)).ReturnsAsync(expectedCities);

            // Act
            var result = await _controller.Delete(cityId);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<ActionResult<List<CityResponse>>>(result);
            var actualCitiesResponse = Assert.IsType<OkObjectResult>(okResult.Result).Value;

            // Add more specific assertions based on your requirements
            Assert.IsType<List<CityResponse>>(actualCitiesResponse);
            Assert.Equal(expectedCities, actualCitiesResponse as List<CityResponse>);
        }

        #region Setup
        public static List<CityResponse> GetSampleCityList()
        {
            return new List<CityResponse>
            {
                new CityResponse { CityId = 1, CityName = "City1" },
                new CityResponse { CityId = 2, CityName = "City2" }
                // Add more city responses as needed
            };
        }

        //private void Setup()
        //{
        //    var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        //}
        #endregion
    }
}
