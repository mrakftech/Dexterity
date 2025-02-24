using System.ComponentModel.DataAnnotations;

namespace Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class PasswordRequirementsAttribute : ValidationAttribute
{
    // Minimum length for the password
    public int MinLength { get; set; } = 12;

    // Override the IsValid method to implement custom validation logic
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;

        // Check if the password is null or empty
        if (string.IsNullOrEmpty(password))
        {
            return new ValidationResult("Password is required.");
        }

        // Check minimum length
        if (password.Length < MinLength)
        {
            return new ValidationResult($"Password must be at least {MinLength} characters long.");
        }

        // Check for at least one uppercase letter
        if (!password.Any(char.IsUpper))
        {
            return new ValidationResult("Password must contain at least one uppercase letter.");
        }

        // Check for at least one numeric character
        if (!password.Any(char.IsDigit))
        {
            return new ValidationResult("Password must contain at least one numeric character.");
        }

        // Check for at least one special character
        var specialCharacters = "!@#$%^&*()_+";
        if (!password.Any(c => specialCharacters.Contains(c)))
        {
            return new ValidationResult("Password must contain at least one special character.");
        }

        // If all checks pass, return success
        return ValidationResult.Success;
    }
}