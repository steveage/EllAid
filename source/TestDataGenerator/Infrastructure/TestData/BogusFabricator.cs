using System;
using System.Collections.Generic;
using Bogus;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;

namespace EllAid.TestDataGenerator.Infrastructure.TestData
{
    class BogusFabricator : IDataFabricator
    {
        readonly Faker faker;
        public BogusFabricator() => faker = new Faker();

        public DateTime GetRandomPastDate(int yearsToGoBack, DateTime refDate) => faker.Date.Past(yearsToGoBack, refDate);

        public string PickRandom(List<string> items) => faker.PickRandom(items);

        public string PickRandomFirstName(Gender gender) => faker.Name.FirstName(GetBogusGender(gender));

        Bogus.DataSets.Name.Gender GetBogusGender(Gender gender) => (Bogus.DataSets.Name.Gender)gender;

        public Gender PickRandomGender()
        {
            Gender gender = faker.PickRandom<Gender>();
            return gender==Gender.Invalid?PickRandomGender():gender;
        }

        public string PickRandomLastName(Gender gender) => faker.Name.LastName(GetBogusGender(gender));

        public int PickRandomNumber(int min, int max) => faker.Random.Number(min, max);
    }
}