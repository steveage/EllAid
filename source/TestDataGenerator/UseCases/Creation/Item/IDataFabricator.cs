using System;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    public interface IDataFabricator
    {
        string PickRandom(string[] items);
        DateTime GetRandomPastDate(int yearsToGoBack, DateTime refDate);
        Gender PickRandomGender();
        string PickRandomFirstName(Gender gender);
        string PickRandomLastName(Gender gender);
        int PickRandomNumber(int min, int max);
    }
}