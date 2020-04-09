using System.Collections.Generic;
using EllAid.TestDataGenerator.UseCases.Adapters;

namespace EllAid.TestDataGenerator.Infrastructure
{
    class InMemoryUserDataProvider : IUserDataAccess
    {
        public List<string> GetFemalePictures() => new List<string> {
                "https://randomuser.me/api/portraits/lego/9.jpg"};

        public List<string> GetLanguages() => new List<string> {"English", "Polish", "Portuguese", "German", "Spanish", "Mandarin", "Thai", "Hindi", "Vietnamese"};

        public List<string> GetMalePictures() => new List<string> {
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