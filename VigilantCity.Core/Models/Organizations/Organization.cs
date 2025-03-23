namespace VigilantCity.Core.Models.Organizations
{
    public abstract record Organization(Guid LeaderId, string Name);
}