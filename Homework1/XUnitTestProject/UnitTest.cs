using Bogus;
using Homework1;
using Moq;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest
    {
        [Theory]
        [InlineData(8, 28, 4)]
        [InlineData(9, 33, 3)]
        [InlineData(16, 40, 8)]
        public void EuclideanGcdMethodCalculationTest(int firstValue, int secondValue, int expectedResult)
        {
            var testingService = new FindGcdService();

            var actualResult = testingService.EuclideanGcdMethod(firstValue, secondValue);


            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void EuclideanGcdMethodMoqCallbackTest(int firstValue, int secondValue, int expectedResult)
        {
            int firstCallback = 0;
            int secondCallback = 0;

            var findGcdServiceMock = new Mock<IFindGcdService>();
            findGcdServiceMock.Setup(f => f.EuclideanGcdMethod(It.IsAny<int>(), It.IsAny<int>()))
                              .Callback<int, int>((f, s) =>
                              { 
                                  firstCallback = f;
                                  secondCallback = s;
                              })
                              .Returns(expectedResult);

            int Func(int f, int s) => findGcdServiceMock.Object.EuclideanGcdMethod(f, s);


            Assert.Equal(expectedResult, Func(firstValue, secondValue));
            Assert.Equal(firstCallback, firstValue);
            Assert.Equal(secondCallback, secondValue);
        }

        [Fact]
        public void EuclideanGcdMethodWithBogusTest()
        {
            int fakesCount = 5;

            var faker = new Faker<FindGcdService>()
                .RuleFor(c => c.FirstValue, f => f.Random.Int(-1000, 1000))
                .RuleFor(c => c.SecondValue, f => f.Random.Int(-1000, 1000));

            var fakeServices = faker.Generate(fakesCount);


            int successCalculationCount = 0;

            foreach (var fakeService in fakeServices)
            {
                int gcd = fakeService.EuclideanGcdMethod(fakeService.FirstValue, fakeService.SecondValue);

                if (fakeService.FirstValue % gcd == 0 && fakeService.SecondValue % gcd == 0)
                {
                    successCalculationCount++;
                }
            }


            Assert.Equal(fakesCount, successCalculationCount);
        }
    }
}
