namespace ProjectVFront.Crosscutting.Utils;

public class UsersWebApiOptions
{
    public const string SectionName = nameof(UsersWebApiOptions);

    public string UsersRoute { get; set; }
    public string UsersGetUserInfoAction { get; set; }
    public string UsersUpdateUserInfoAction { get; set; }
}
