namespace Byteology.Website.Components;

using Byteology.Website.Pages.Services;

public partial class ServicesList : ComponentBase
{
    private readonly Model[] _services;

    public ServicesList()
    {
        _services = this.ReadJsonModel<Model[]>();

        _services[0].PageType = typeof(SoftwareDevelopment);
        _services[1].PageType = typeof(ResearchAndPoc);
        _services[2].PageType = typeof(MigrationToMicroservices);
        _services[3].PageType = typeof(EventSourcing);
        _services[4].PageType = typeof(ConsultingAndTraining);
        _services[5].PageType = typeof(InterviewingAsAService);
    }

    private sealed record Model(string Title, string Description, string IconSrc, string LinkText)
    {
        public Type? PageType { get; set; }
    }


}
