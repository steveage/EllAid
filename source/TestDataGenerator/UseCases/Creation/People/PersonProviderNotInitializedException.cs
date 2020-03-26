using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.People
{
    class PersonProviderNotInitializedException : Exception
    {
        public PersonProviderNotInitializedException(string message) : base(message)
        {
            
        }
    }
}