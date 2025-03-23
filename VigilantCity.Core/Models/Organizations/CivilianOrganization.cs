namespace VigilantCity.Core.Models.Organizations
{
    public record CivilianOrganization(Guid LeaderId, string Name) : Organization(LeaderId, Name);
}