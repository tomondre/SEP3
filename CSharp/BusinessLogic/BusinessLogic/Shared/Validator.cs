using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing;

namespace BusinessLogic.Shared
{
    public class Validator
    {
        public bool isValidCvr(int cvr)
        {
            return cvr is >= 10000000 and <= 99999999;
        }
        
        public bool isValidPostCode(int postCode)
        {
            return postCode is >= 1000 and <= 9999;
        }
        
        public static bool isValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,14}$");
            Match match = regex.Match(password);
            return match.Success;
        }
        
        public static bool isValidEmail(string email)
        {
            Regex regex = new Regex( @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                     @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                                     @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        
        
    }
    
}