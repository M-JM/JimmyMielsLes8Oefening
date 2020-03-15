using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DataAccessLayer.Attributes
{
    public class BankAccountNumberAttribute : RegularExpressionAttribute
    {
        public BankAccountNumberAttribute() : base(@"[a-zA-Z]{2}[0-9]{2}\s{1}[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}")
        {
            ErrorMessage = "Please provide a valid Bank account number address";
        }
    }
}
