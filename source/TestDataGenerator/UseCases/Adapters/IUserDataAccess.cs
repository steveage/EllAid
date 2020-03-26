using System.Collections.Generic;

namespace EllAid.TestDataGenerator.UseCases.Adapters
{
    public interface IUserDataAccess
    {
        List<string> GetMalePictures();
        List<string> GetFemalePictures();
        List<string> GetLanguages();
    }
}