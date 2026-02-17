namespace ASP_Identity.Services;

public interface IEmailService
{
    Task SendResetPasswordEmail(string resetPasswordEmailLink, string ToEmail);
}
