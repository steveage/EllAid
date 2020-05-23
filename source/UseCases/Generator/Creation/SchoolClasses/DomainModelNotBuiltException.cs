using System;

namespace EllAid.UseCases.Generator.Creation.SchoolClasses
{
    class DomainModelNotBuiltException : Exception
    {
        public DomainModelNotBuiltException(string message) : base(message) {}
    }
}