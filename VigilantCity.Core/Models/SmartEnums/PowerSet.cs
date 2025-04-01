using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using VigilantCity.Core.Models.Enumerations;
using VigilantCity.Core.Models.SmartEnums;

namespace VigilantCity.Core.Models.PowerSets
{
    [JsonConverter(typeof(PowerSetJsonConverter))]
    public sealed class PowerSet
    {
        public string Name { get; }
        public string DisplayName { get; }

        private PowerSet(string name, string? displayName = null)
        {
            Name = name;
            DisplayName = displayName ?? name;
        }

        public static readonly PowerSet Flight = new(nameof(Flight), "Flight");
        public static readonly PowerSet SuperStrength = new(nameof(SuperStrength), "Super Strength");
        public static readonly PowerSet SuperSpeed = new(nameof(SuperSpeed), "Super Speed");
        public static readonly PowerSet Telekinesis = new(nameof(Telekinesis), "Telekinesis");
        public static readonly PowerSet Telepathy = new(nameof(Telepathy), "Telepathy");
        public static readonly PowerSet Invisibility = new(nameof(Invisibility), "Invisibility");
        public static readonly PowerSet Healing = new(nameof(Healing), "Healing");
        public static readonly PowerSet ElementalControl = new(nameof(ElementalControl), "Elemental Control");
        public static readonly PowerSet Shapeshifting = new(nameof(Shapeshifting));
        public static readonly PowerSet TimeManipulation = new(nameof(TimeManipulation), "Time Manipulation");
        public static readonly PowerSet EnergyManipulation = new(nameof(EnergyManipulation), "Energy Manipulation");
        public static readonly PowerSet SizeManipulation = new(nameof(SizeManipulation), "Size Manipulation");
        public static readonly PowerSet AnimalCommunication = new(nameof(AnimalCommunication), "Animal Communication");
        public static readonly PowerSet Technopathy = new(nameof(Technopathy), "Technopathy");
        public static readonly PowerSet Teleportation = new(nameof(Teleportation), "Teleportation");
        public static readonly PowerSet Precognition = new(nameof(Precognition), "Precognition");
        public static readonly PowerSet SuperSenses = new(nameof(SuperSenses), "Super Senses");
        public static readonly PowerSet CombatMaster = new("CombatMaster", "Combat Master");
        public static readonly PowerSet SuperiorDeduction = new("SuperiorDeduction", "Superior Deduction");
        public static readonly PowerSet SuperiorKnowledge = new("SuperiorKnowledge", "Superior Knowledge");
        public static readonly PowerSet ArmoredBody = new("ArmoredBody", "Armored Body");
        public static readonly PowerSet MasterMarksman = new("MasterMarksman", "Master Marksman");

        public override string ToString() => DisplayName;

        public static IEnumerable<PowerSet> List()
        {
            return
            [
                Flight,
                SuperStrength,
                SuperSpeed,
                Telekinesis,
                Telepathy,
                Invisibility,
                Healing,
                ElementalControl,
                Shapeshifting,
                TimeManipulation,
                EnergyManipulation,
                SizeManipulation,
                AnimalCommunication,
                Technopathy,
                Teleportation,
                Precognition,
                SuperSenses,
                CombatMaster,
                SuperiorDeduction,
                SuperiorKnowledge,
                ArmoredBody,
                MasterMarksman
            ];
        }
    }
}