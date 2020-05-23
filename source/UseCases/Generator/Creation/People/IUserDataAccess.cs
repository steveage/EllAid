using System.Collections.Generic;

namespace EllAid.UseCases.Generator.Creation.People
{
    public interface IUserDataAccess
    {
        List<string> GetMalePictures();
        List<string> GetFemalePictures();
        List<string> GetLanguages();
    }
}