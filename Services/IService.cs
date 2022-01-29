namespace DILifetime.Services
{
    public interface IService
    {
        DateTime InstanceCreationTime { get; set; }
        Guid InstanceId { get; set; }
    }
}