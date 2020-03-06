using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class PersonProvider : IPersonProvider
    {
        readonly IUserCreator creator;
        bool isInitialized;
        int numberOfRequests = 0;
        List<Person> users;
        public string Type { get; private set; }
        public int Count { get; private set; }

        public PersonProvider(IUserCreator creator)
        {
            this.creator = creator;
        }
        
        public void Initialize(int count)
        {
            if (count > 0)
            {
                Count = count;
                users = creator.CreatePeople(count);
                isInitialized = true;
            }
            else
            {
                throw new PersonProviderNotInitializedException($"The value for {nameof(count)} parameters is invalid.");
            }
        }

        public Person GetPerson()
        {
            if (isInitialized)
            {
                numberOfRequests++;
                int userIndex = (numberOfRequests-1)%Count;
                return users[userIndex];
            }
            else
            {
                throw new PersonProviderNotInitializedException("Provider must be initialized first.");
            }
        }

        public List<Person> GetPeople()
        {
            if (isInitialized)
            {
                return users;
            }
            else
            {
                throw new PersonProviderNotInitializedException("Provider must be initialized first.");
            }
        }
    }
}