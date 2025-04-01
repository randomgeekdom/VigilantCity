using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Enumerations
{
    public enum Approach
    {
        [Display(Name = "Diplomatic", Description = "Talk it out.")]
        Diplomatic, 

        [Display(Name = "Lethal", Description = "When in doubt, kill them.")]
        Lethal, 

        [Display(Name = "Stealthy", Description = "Try not to be seen.")]
        Stealthy,  

        [Display(Name = "Swift", Description = "Be quick.")]
        Swift,  

        [Display(Name = "Tactical", Description = "Use your wits.")]
        Tactical 
    }
}