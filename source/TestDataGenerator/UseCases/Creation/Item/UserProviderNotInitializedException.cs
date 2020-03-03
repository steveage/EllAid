using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class UserProviderNotInitializedException : Exception
    {
        public UserProviderNotInitializedException(string message) : base(message)
        {
            
        }
    }
}