using System;
using Bogus;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases.Creation.Item;

namespace EllAid.TestDataGenerator.Infrastructure.TestData
{
    class FakeDataProvider : IFakeData
    {
        readonly Faker faker;
        public FakeDataProvider()
        {
            faker = new Faker();
        }

        public DateTime GetRandomPastDate(int yearsToGoBack, DateTime refDate) => faker.Date.Past(4, refDate);

        public string PickRandom(string[] items) => faker.PickRandom(items);

        public string PickRandomFirstName(Gender gender) => faker.Name.FirstName(GetBogusGender(gender));

        Bogus.DataSets.Name.Gender GetBogusGender(Gender gender) => (Bogus.DataSets.Name.Gender)gender;

        public Gender PickRandomGender() => faker.PickRandom<Gender>();

        public string PickRandomLastName(Gender gender) => faker.Name.LastName(GetBogusGender(gender));

        public int PickRandomNumber(int min, int max) => faker.Random.Number(min, max);
    }
}