namespace ProjectVFront.Crosscutting.Utils;

public class CategoriesWebApiOptions
{
    public const string SectionName = nameof(CategoriesWebApiOptions);

    public string CategoriesRoute { get; set; }
    public string CategoriesAddAction { get; set; }
    public string CategoriesGetAction { get; set; }
    public string CategoriesGetAllAction { get; set; }
    public string CategoriesEditAction { get; set; }
    public string CategoriesDeleteAction { get; set; }
}
