using System.ComponentModel.DataAnnotations;

namespace VigilantCity.Core.Models
{
    public enum PowerSet
    {
        Flight,
        [Display(Name = "Super Strength")]
        SuperStrength,
        [Display(Name = "Super Speed")]
        SuperSpeed,
        Telekinesis,
        Telepathy,
        Invisibility,
        Healing,
        [Display(Name = "Elemental Control")]
        ElementalControl,
        Shapeshifting,
        [Display(Name = "Time Manipulation")]
        TimeManipulation,
        [Display(Name = "Energy Manipulation")]
        EnergyManipulation,
        Duplication,
        [Display(Name = "Size Manipulation")]
        SizeManipulation,
        [Display(Name = "Animal Communication")]
        AnimalCommunication,
        Technopathy,
        Teleportation,
        Precognition,
        [Display(Name = "Super Senses")]
        SuperSenses,
    }
}