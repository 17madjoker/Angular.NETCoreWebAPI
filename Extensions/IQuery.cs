namespace AngularCoreApp.Extensions
{
    public interface IQuery
    {
        string SortBy { get; set; }
        
        bool IsSortAsc { get; set; }
        
        int Page { get; set; }
        
        int PageSize { get; set; }
    }
}