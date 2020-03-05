using System.Collections.Generic;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    public interface IUserDataAccess
    {
        List<string> GetMalePictures();
        List<string> GetFemalePictures();
        List<string> GetLanguages();
    }
}