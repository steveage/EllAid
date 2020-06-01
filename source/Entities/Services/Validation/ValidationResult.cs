using System.Collections.Generic;

namespace EllAid.Entities.Services.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }
        
        public bool IsValid { get; set; }
        public IList<ValidationError> Errors { get; set; }
    }
}