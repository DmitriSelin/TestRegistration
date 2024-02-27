namespace TestRegistration.Web.Models;

public sealed class User
{
    public Guid Id { get; init; }

    public string Email { get; private set; }

    public int VerificationCode { get; private set; }

    public bool IsVerified { get; private set; } = false;

    public static User Create(string email)
    {
        int verificationCode = new Random()
            .Next(1000, 9999);

        return new(email, verificationCode);
    }

    public void Verify()
    {
        IsVerified = true;
    }

    private User(string email, int verificationCode)
    {
        Id = Guid.NewGuid();
        Email = email;
        VerificationCode = verificationCode;
    }
}