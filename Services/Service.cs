namespace DILifetime.Services
{
    public class Service : IScopedService,ITransientService,ISingletonService
    {
        public Service()
        {
            InstanceCreationTime = DateTime.Now;
            InstanceId = Guid.NewGuid();
        }

        public DateTime InstanceCreationTime { get ; set ; }
        public Guid InstanceId { get ; set ; }
    }
}