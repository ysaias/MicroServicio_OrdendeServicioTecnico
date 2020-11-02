namespace Tienda.SharedKernel.Core
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}