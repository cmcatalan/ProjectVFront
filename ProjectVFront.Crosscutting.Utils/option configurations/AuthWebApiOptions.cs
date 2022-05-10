namespace ProjectVFront.Crosscutting.Utils;

public class AuthWebApiOptions
{
    public const string SectionName = nameof(AuthWebApiOptions);

    public string AuthRoute { get; set; }
    public string AuthLoginAction { get; set; }
    public string AuthSignupAction { get; set; }
}
