using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Shared.Attributes;

public class GmsNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string gmsNumber = value as string;
        if (gmsNumber == null)
        {
            return false;
        }

        string pattern = @"^(M\d{6}[A-Z]|\d{7}[A-Z])$";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(gmsNumber);
    }
}