using System.Collections.Generic;
using EllAid.Entities.Services.Validation;

namespace EllAid.UseCases.Dashboard.SignIn
{
    public interface IErrorCollector
    {
        int Count { get; }

        void AddError(ValidationError error);
        void AddErrors(IList<ValidationError> errors);
        void Save();
    }
}