using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Enumerations
{
    [Flags]
    public enum PowerOrigin
    {
        [Display(Description = "Your powers were either granted to you by an alien from another world, universe, or dimension.  Or, perhaps, you are that alien being yourself.")]
        Alien,
        [Display(Description = "You were born this way.  Whether accelerated by some precipiating event or just the next step in evolution, your powers are an extension of your innate being.")]
        Mutation,
        [Display(Description = "Your powers are granted to you by the divine, demonic, or mythological.  Maybe you're a creature of mythology.")]
        Supernatural,
        [Display(Description = "Science has granted you abilities beyond what is normal.  You wear a piece of technology or have made it a part of your body.")]
        Technological
    }
}