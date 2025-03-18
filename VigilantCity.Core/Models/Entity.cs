namespace VigilantCity.Core.Models
{
    public abstract record Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public override int GetHashCode() => Id.GetHashCode();
    }
}