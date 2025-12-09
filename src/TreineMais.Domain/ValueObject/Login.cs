using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace TreineMais.Domain.ValueObject;

public class Login
{
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    
    private Login() { }

    public Login(Email email, Password password)
    {
        Email = email;
        Password = password;
    }
}

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email address.", nameof(value));
        
        Value = value;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}

public class Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password cannot be empty.", nameof(Password));
        if (value.Length < 8)
            throw new ArgumentException("Password must contain at least 8 characters.", nameof(Password));
        Value = value;
    }
}