using System;

namespace EllAid.UseCases.Generator.Creation.People
{
    class PersonProviderNotInitializedException : Exception
    {
        public PersonProviderNotInitializedException(string message) : base(message)
        {
            
        }
    }
}