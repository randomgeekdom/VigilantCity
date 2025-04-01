using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Enumerations
{
    [Flags]
    public enum PowerOrigin
    {
        [Display(Description = "Your powers were either granted to you by an alien from another world, universe, or dimension.  Or, perhaps, you are that alien being yourself.")]
        Alien,
        [Display(Description = "You were born this way.  Something unknown within your DNA has caused you to have special abilities.")]
        Evolutionary,
        [Display(Description = "Your powers are granted to you by sorcery, myth, or the divine/demonic.")]
        Supernatural,
        [Display(Description = "Science has granted you abilities beyond what is normal.  You wear a piece of technology or have made it a part of your body.")]
        Technological
    }
}