using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Helper;

public class ValidatePlayerNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        const string pattern = @"^[a-zA-Z0-9]+$";
        var name = Convert.ToString(value) ;
        var isValid = Regex.IsMatch(name, pattern);
        if (string.IsNullOrWhiteSpace(name)) return new ValidationResult("A player name is required");
        if (name.Length > 12) return new ValidationResult("The player name cannot be longer than 12 characters");
        if (!isValid) return new ValidationResult("The player name can only consist of numbers or letters.");
        return ValidationResult.Success;
    }
}