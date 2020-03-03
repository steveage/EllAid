using EllAid.TestDataGenerator.UseCases.Creation.Item;

namespace EllAid.TestDataGenerator.Infrastructure.TestData
{
    class UserDataProvider : IUserDataAccess
    {
        public string[] GetFemalePictures() => new[] {
                "https://randomuser.me/api/portraits/lego/9.jpg"};

        public string[] GetLanguages() => new[] {"English", "Polish", "Portuguese", "German", "Spanish", "Mandarin", "Thai", "Hindi", "Vietnamese"};

        public string[] GetMalePictures() => new[] {
                "https://randomuser.me/api/portraits/lego/0.jpg",
                "https://randomuser.me/api/portraits/lego/1.jpg",
                "https://randomuser.me/api/portraits/lego/2.jpg", 
                "https://randomuser.me/api/portraits/lego/3.jpg",
                "https://randomuser.me/api/portraits/lego/4.jpg",
                "https://randomuser.me/api/portraits/lego/5.jpg",
                "https://randomuser.me/api/portraits/lego/6.jpg",
                "https://randomuser.me/api/portraits/lego/7.jpg",
                "https://randomuser.me/api/portraits/lego/8.jpg",
                };
    }
}