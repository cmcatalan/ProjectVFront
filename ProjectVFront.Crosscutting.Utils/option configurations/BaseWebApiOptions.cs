namespace ProjectVFront.Crosscutting.Utils;

public class BaseWebApiOptions
{
    public const string SectionName = nameof(BaseWebApiOptions);

    public string BaseUrl { get; set; }
    public string ApiVersion { get; set; }
}
