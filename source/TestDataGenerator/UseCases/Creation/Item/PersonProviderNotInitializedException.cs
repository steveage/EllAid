using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class PersonProviderNotInitializedException : Exception
    {
        public PersonProviderNotInitializedException(string message) : base(message)
        {
            
        }
    }
}