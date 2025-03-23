namespace VigilantCity.Core.Models.Organizations
{
    public record CriminalOrganization(Guid LeaderId, string Name) : Organization(LeaderId, Name);
}