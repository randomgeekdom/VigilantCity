using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Enumerations
{
    public enum Approach
    {
        [Display(Name = "Empowered", Description = "Use powers whenever possible.")]
        Empowered,  // Uses superpowers wherever possible

        [Display(Name ="Lethal", Description ="When in doubt, kill them.")]
        Lethal, // When in doubt, kill the MFer

        [Display(Name ="Stealthy", Description = "Try not to be seen.")]
        Stealthy,   // Try to avoid being seen

        [Display(Name = "Swift", Description = "Be quick.")]
        Swift,  // Be as quick as possible

        [Display(Name ="Tactical", Description = "Use your wits.")]
        Tactical   //  Use your mind
    }
}