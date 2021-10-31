using GrpcFileGeneration.Models;

namespace ClientBlazor.Data
{
    public interface IHandShakeService
    {
        public HandShake HandShake { get; }
    }
}