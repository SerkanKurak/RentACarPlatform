namespace RentACarPlatform.Core.Exceptions
{
    public class Guard : IGuard
    {
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new RentACarException() :
                    new RentACarException(errorMessage);

                throw exception;
            }
        }
    }
}
