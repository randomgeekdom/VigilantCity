using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using VigilantCity.Core.Models.Enumerations;

namespace VigilantCity.Core.Models.PowerSets
{
    [JsonConverter(typeof(PowerSetJsonConverter))]
    public sealed class PowerSet
    {
        public string Name { get; }
        public string DisplayName { get; }
        public Skill? RelatedSkill { get; }

        private PowerSet(string name, string? displayName = null, Skill? relatedSkill = null)
        {
            Name = name;
            DisplayName = displayName ?? name;
            RelatedSkill = relatedSkill;
        }

        public static readonly PowerSet Flight = new(nameof(Flight), relatedSkill: Skill.Movement);
        public static readonly PowerSet SuperStrength = new(nameof(SuperStrength), "Super Strength", relatedSkill: Skill.Brawn);
        public static readonly PowerSet SuperSpeed = new(nameof(SuperSpeed), "Super Speed", relatedSkill: Skill.Movement);
        public static readonly PowerSet Telekinesis = new(nameof(Telekinesis), relatedSkill: Skill.Willpower);
        public static readonly PowerSet Telepathy = new(nameof(Telepathy), relatedSkill: Skill.Influence);
        public static readonly PowerSet Invisibility = new(nameof(Invisibility), relatedSkill: Skill.Movement);
        public static readonly PowerSet Healing = new(nameof(Healing), relatedSkill: Skill.Assist);
        public static readonly PowerSet ElementalControl = new(nameof(ElementalControl), "Elemental Control", relatedSkill: Skill.Aura);
        public static readonly PowerSet Shapeshifting = new(nameof(Shapeshifting));
        public static readonly PowerSet TimeManipulation = new(nameof(TimeManipulation), "Time Manipulation", relatedSkill: Skill.Aura);
        public static readonly PowerSet EnergyManipulation = new(nameof(EnergyManipulation), "Energy Manipulation", relatedSkill: Skill.Aura);
        public static readonly PowerSet SizeManipulation = new(nameof(SizeManipulation), "Size Manipulation", relatedSkill: Skill.Brawn);
        public static readonly PowerSet AnimalCommunication = new(nameof(AnimalCommunication), "Animal Communication", relatedSkill: Skill.Aura);
        public static readonly PowerSet Technopathy = new(nameof(Technopathy), relatedSkill: Skill.Tinker);
        public static readonly PowerSet Teleportation = new(nameof(Teleportation), relatedSkill: Skill.Movement);
        public static readonly PowerSet Precognition = new(nameof(Precognition), relatedSkill: Skill.Destiny);
        public static readonly PowerSet SuperSenses = new(nameof(SuperSenses), "Super Senses", relatedSkill: Skill.Sense);
        public static readonly PowerSet CombatMaster = new("CombatMaster", "Combat Master", relatedSkill: Skill.Melee);
        public static readonly PowerSet SuperiorDeduction = new("SuperiorDeduction", "Superior Deduction", relatedSkill: Skill.Deduction);
        public static readonly PowerSet SuperiorKnowledge = new("SuperiorKnowledge", "Superior Knowledge", relatedSkill: Skill.Knowledge);
        public static readonly PowerSet ArmoredBody = new("ArmoredBody", "Armored Body", relatedSkill: Skill.Resilience);
        public static readonly PowerSet MasterMarksman = new("MasterMarksman", "Master Marksman", relatedSkill: Skill.Target);

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