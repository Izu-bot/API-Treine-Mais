using System.Net.Mail;

namespace TreineMais.Domain.ValueObject;

public class Login
{
    private Login()
    {
    }

    public Login(Email email, Password password)
    {
        Email = email;
        Password = password;
    }

    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
}

public class Email
{
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email address.", nameof(value));

        Value = value;
    }

    public string Value { get; }

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
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password cannot be empty.", nameof(Password));
        if (value.Length < 8)
            throw new ArgumentException("Password must contain at least 8 characters.", nameof(Password));
        Value = value;
    }

    public string Value { get; }
}