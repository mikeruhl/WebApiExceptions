using WebApiPlayground.Api.Exceptions;

namespace WebApiPlayground.Api.Services
{
    public class ExceptionService
    {
        public void ThrowLevel2Exception(int id)
        {
            throw new Level2Exception($"This is a level 2 exception. Id Multiplier Invalid: {id}");
        }
    }
}