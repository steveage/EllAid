namespace EllAid.Entities.Services.Validation
{
    public interface IValidator<T> where T : class
    {
        ValidationResult Validate(T item);
    }
}