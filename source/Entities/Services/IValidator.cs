namespace EllAid.Entities.Services
{
    public interface IValidator<T> where T : class
    {
        bool IsValid(T item);
    }
}