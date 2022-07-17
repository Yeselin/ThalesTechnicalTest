namespace Thales.CommonInterfaces.DTO
{
    public interface IDataComplete_DTO
    {
        string status { get; set; }
        IEmployee_DTO[] data { get; set; }
        string message { get; set; }
    }

}
