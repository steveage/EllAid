using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    public interface IDataFabricator
    {
        string PickRandom(List<string> items);
        DateTime GetRandomPastDate(int yearsToGoBack, DateTime refDate);
        Gender PickRandomGender();
        string PickRandomFirstName(Gender gender);
        string PickRandomLastName(Gender gender);
        int PickRandomNumber(int min, int max);
    }
}