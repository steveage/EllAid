namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    public interface IUserDataAccess
    {
        string[] GetMalePictures();
        string[] GetFemalePictures();
        string[] GetLanguages();
    }
}