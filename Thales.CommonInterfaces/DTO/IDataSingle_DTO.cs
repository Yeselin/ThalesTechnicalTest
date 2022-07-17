namespace Thales.CommonInterfaces.DTO
{
    public interface IDataSingle_DTO
    {
        string status { get; set; }
        IEmployee_DTO data { get; set; }
        string message { get; set; }
    }
}
