using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using PandaApplication.Interfaces.Repositories;
using PandaApplication.Services;
using PandaDomain.Models.Response;

namespace PandaAPIUnitTesting.ServiceTests
{
    public class CityServiceTests
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityServiceTests()
        {
            _cityRepository = A.Fake<ICityRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CityService_GetListCity_Success()
        {
            //Arrange
            var cities = A.Fake<ICollection<CityResponse>>();
            var cityList = A.Fake<List<CityResponse>>();
            A.CallTo(() => _mapper.Map<List<CityResponse>>(cities)).Returns(cityList);
            var service = new CityService(_cityRepository);
            //Act
            var result = service.GetListCity();
            //Assert
            result.Should().NotBeNull();
        }
    }
}
