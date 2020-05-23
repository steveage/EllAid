using System;
using System.Collections.Generic;
using EllAid.Entities.Data;
using Xunit;
using EllAid.Details.Main.DataFabricator;

namespace EllAid.Tests.Details.Main.DataFabricator
{
    public class BogusFabricatorTests
    {
        [Fact]
        public void PickRandomGender_ReturnsValidGender()
        {
            //Given
            BogusFabricator fabricator = new BogusFabricator();
            
            //When
            List<Gender> randomGenders = new List<Gender>() {
                fabricator.PickRandomGender(),
                fabricator.PickRandomGender(),
                fabricator.PickRandomGender(),
                fabricator.PickRandomGender(),
                fabricator.PickRandomGender(),
                fabricator.PickRandomGender(),
                fabricator.PickRandomGender()
            };

            //Then
            Assert.All<Gender>(randomGenders, gender => Assert.NotEqual(Gender.Invalid, gender));
        }

        [Fact]
        public void GetRandomPastDate_ReturnsPastDate()
        {
            //Given
            BogusFabricator fabricator = new BogusFabricator();
            DateTime referenceDate = new DateTime(2020, 1, 1);
            const int yearsToGoBack = 4;
            int maxDaysToGoBack = yearsToGoBack * 365;

            //When
            List<DateTime> pastDates = new List<DateTime>() {
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate),
                fabricator.GetRandomPastDate(yearsToGoBack, referenceDate)
            };

            //Then
            Assert.All<DateTime>(pastDates, pastDate => Assert.True((referenceDate - pastDate).Days<maxDaysToGoBack));
        }

        [Fact]
        public void PickRandom_ReturnsStringFromArray()
        {
            //Given
            BogusFabricator fabricator = new BogusFabricator();
            List<string> strings = new List<string> { "abc", "def", "ghi", "jkl", "mno","prs", "tuv", "wxy"};

            //When
            List<string> randomStrings = new List<string>() {
                fabricator.PickRandom(strings),
                fabricator.PickRandom(strings),
                fabricator.PickRandom(strings),
                fabricator.PickRandom(strings),
                fabricator.PickRandom(strings),
                fabricator.PickRandom(strings),
                fabricator.PickRandom(strings)
            };
        
            //Then
            Assert.All<string>(randomStrings, randomString => Assert.Contains(randomString, strings));
        }

        [Fact]
        public void PickRandomFirstName_ReturnsValidString()
        {
            //Given
            BogusFabricator fabricator = new BogusFabricator();

            //When
            List<string> firstNames = new List<string>() {
                fabricator.PickRandomFirstName(Gender.Male),
                fabricator.PickRandomFirstName(Gender.Male),
                fabricator.PickRandomFirstName(Gender.Male),
                fabricator.PickRandomFirstName(Gender.Female),
                fabricator.PickRandomFirstName(Gender.Female),
                fabricator.PickRandomFirstName(Gender.Female)
            };

            //Then
            Assert.All<string>(firstNames, firstName => Assert.NotEmpty(firstName));
            Assert.All<string>(firstNames, firstName => Assert.NotNull(firstName));
        }

        [Fact]
        public void PickRandomLastName_ReturnsValidString()
        {
            //Given
            BogusFabricator fabricator = new BogusFabricator();

            //When
            List<string> lastNames = new List<string>() {
                fabricator.PickRandomLastName(Gender.Male),
                fabricator.PickRandomLastName(Gender.Male),
                fabricator.PickRandomLastName(Gender.Male),
                fabricator.PickRandomLastName(Gender.Female),
                fabricator.PickRandomLastName(Gender.Female),
                fabricator.PickRandomLastName(Gender.Female)
            };
            //Then
            Assert.All<string>(lastNames, lastName => Assert.NotEmpty(lastName));
            Assert.All<string>(lastNames, lastName => Assert.NotEmpty(lastName));
        }

        [Fact]
        public void PickRandomNumber_ReturnsNumberFromRange()
        {
            //Given
            BogusFabricator fabricator = new BogusFabricator();
            const int min = 1000;
            const int max = 10000;

            //When
            List<int> randomNumbers = new List<int>() {
                fabricator.PickRandomNumber(min, max),
                fabricator.PickRandomNumber(min, max),
                fabricator.PickRandomNumber(min, max),
                fabricator.PickRandomNumber(min, max),
                fabricator.PickRandomNumber(min, max),
                fabricator.PickRandomNumber(min, max)
            };

            //Then
            Assert.All<int>(randomNumbers, randomNumber => Assert.True(randomNumber>min));
            Assert.All<int>(randomNumbers, randomNumber => Assert.True(randomNumber<max));
        }
    }
}