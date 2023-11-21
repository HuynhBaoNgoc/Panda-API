using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using PandaAPI.Controllers;
using PandaApplication.Services.Interfaces;
using PandaDomain.Models.Request;
using PandaDomain.Models.Response;

namespace PandaAPIUnitTesting.ControllerTests
{
    public class CityControllerTests
    {
        private readonly ICityService _cityServices;
        private readonly IMapper _mapper;

        public CityControllerTests() {
            _cityServices = A.Fake<ICityService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async void CityController_GetListCity_ReturnOK()
        {
            //Arrange
            var cities = A.Fake<ICollection<CityResponse>>();
            var cityList = A.Fake<List<CityResponse>>();
            A.CallTo(() => _mapper.Map<List<CityResponse>>(cities)).Returns(cityList);
            var controller = new CityController(_cityServices);
            //Act
            var result = await controller.GetListCity();
            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>(); // Kiểm tra kiểu là OkObjectResult
        }
        [Fact]
        public async void CityController_AddCity_ReturnOK()
        {
            //Arrange
            int cityId = 1;
            string cityName = "Trung Khanh";
            var cityRequest = A.Fake<AddCityRequest>();
            var cities = A.Fake<ICollection<CityResponse>>();
            var cityList = A.Fake<List<CityResponse>>();
            A.CallTo(() => _mapper.Map<List<CityResponse>>(cities)).Returns(cityList);
            var controller = new CityController(_cityServices);
            //Act
            var result = await controller.GetListCity();
            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>(); // Kiểm tra kiểu là OkObjectResult
        }
    }
}
