using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models.Enumerations
{
    public enum District
    {
        [Display(Name = "Arts District")]
        ArtsDistrict,
        [Display(Name = "Blue Coast")]
        BlueCoast,
        [Display(Name = "College Park")]
        CollegePark,
        Downtown,
        [Display(Name = "Green Hills")]
        GreenHills,
        [Display(Name = "Medical District")]
        MedicalDistrict,
        Midtown,
        [Display(Name = "Old Town")]
        OldTown,
        Riverside
    }
}