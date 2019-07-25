namespace Pandora.NetStandard.Core.Interfaces
{
    public interface TrackedEntity : IEntity
    {
        bool Deleted { get; set; }
    }
}
