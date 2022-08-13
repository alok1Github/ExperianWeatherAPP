namespace Experian.API.Interface
{
    public interface IAppSettings<T> where T : class
    {
        Task<T> GetAppSettings();
    }
}
