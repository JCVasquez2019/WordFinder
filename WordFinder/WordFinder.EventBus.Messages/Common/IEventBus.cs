namespace WordFinder.EventBus.Messages.Common
{
    public interface IEventBus
    {
        Task PublishAsync(IntegrationBaseEvent integrationEvent);
    }
}