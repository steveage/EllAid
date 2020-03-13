using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class PersonProvider : IPersonProvider
    {
        readonly IPersonCreator creator;
        bool isInitialized;
        int numberOfRequests = 0;
        List<Person> users;
        public int Count { get; private set; }

        public PersonProvider(IPersonCreator creator) => this.creator = creator;
        
        public void Initialize(int count)
        {
            if (count<=0) throw new PersonProviderNotInitializedException($"The value for {nameof(count)} parameters is invalid.");

            Count = count;
            users = creator.CreatePeople<Person>(count);
            isInitialized = true;
        }

        public Person GetPerson()
        {
            if(!isInitialized) throw new PersonProviderNotInitializedException("Provider must be initialized first.");

            numberOfRequests++;
            int userIndex = (numberOfRequests-1)%Count;
            
            return users[userIndex];
        }

        public List<Person> GetPeople()
        {
            if(!isInitialized) throw new PersonProviderNotInitializedException("Provider must be initialized first.");
            
            return users;
        }
    }
}