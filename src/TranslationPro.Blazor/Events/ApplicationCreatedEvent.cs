namespace TranslationPro.Blazor.Events
{
    public class ApplicationCreatedEvent
    {
        public ApplicationCreatedEvent(Guid applicationId)
        {
            ApplicationId = applicationId;
        }
        public Guid ApplicationId { get; set; }
    }
}
