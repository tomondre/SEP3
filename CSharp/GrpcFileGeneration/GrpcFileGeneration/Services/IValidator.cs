namespace GrpcFileGeneration.Services
{
    public interface IValidator
    {
         bool isValidCvr(int cvr);
         bool isValidPostCode(int postCode);
         bool isValidPassword(string password);
         bool isValidEmail(string email);




    }
}