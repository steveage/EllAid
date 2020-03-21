using System;

namespace EllAid.TestDataGenerator.UseCases.Creation.Item
{
    class DomainModelNotBuiltException : Exception
    {
        public DomainModelNotBuiltException(string message) : base(message) {}
    }
}