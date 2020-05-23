using System;
using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.UseCases.Generator.Creation.People
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