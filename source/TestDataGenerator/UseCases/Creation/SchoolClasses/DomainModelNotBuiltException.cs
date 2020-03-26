using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.SchoolClasses
{
    class DomainModelNotBuiltException : Exception
    {
        public DomainModelNotBuiltException(string message) : base(message) {}
    }
}