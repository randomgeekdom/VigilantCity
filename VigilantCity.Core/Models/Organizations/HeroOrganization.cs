namespace VigilantCity.Core.Models.Organizations
{
    public record HeroOrganization(Guid LeaderId, string Name) : Organization(LeaderId, Name);
}