namespace RentACarPlatform.Core.Exceptions
{
    public class RentACarException : ApplicationException
    {
        public RentACarException()
        {

        }

        public RentACarException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
