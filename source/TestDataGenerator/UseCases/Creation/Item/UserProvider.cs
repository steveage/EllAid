using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class UserProvider<T> : IUserProvider<T> where T : User, new()
    {
        readonly IUserCreator creator;
        bool isInitialized;
        int numberOfRequests = 0;
        List<T> users;
        public string Type { get; private set; }
        public int Count { get; private set; }

        public UserProvider(IUserCreator creator)
        {
            this.creator = creator;
        }
        
        public void Initialize(int count)
        {
            if (count > 0)
            {
                Count = count;
                users = creator.CreateUsers<T>(count);
                isInitialized = true;
            }
            else
            {
                throw new UserProviderNotInitializedException($"The value for {nameof(count)} parameters is invalid.");
            }
        }

        public T GetUser()
        {
            if (isInitialized)
            {
                numberOfRequests++;
                int userIndex = (numberOfRequests-1)%Count;
                return users[userIndex];
            }
            else
            {
                throw new UserProviderNotInitializedException("Provider must be initialized first.");
            }
        }

        public List<T> GetUsers()
        {
            if (isInitialized)
            {
                return users;
            }
            else
            {
                throw new UserProviderNotInitializedException("Provider must be initialized first.");
            }
        }
    }
}