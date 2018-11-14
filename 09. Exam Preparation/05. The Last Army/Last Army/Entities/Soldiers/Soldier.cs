using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int MAX_ENDURANCE = 100;
    private const int SOLDIER_REGENERATE_VALUE = 10;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.InitializeWeapons();
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set => this.endurance = Math.Min(value, MAX_ENDURANCE);
    }

    public IDictionary<string, IAmmunition> Weapons { get; private set; }

    public virtual double OverallSkill => this.Experience + this.Age;

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public virtual void Regenerate() => this.Endurance += this.Age + SOLDIER_REGENERATE_VALUE;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        var hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (var weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    private IDictionary<string, IAmmunition> InitializeWeapons()
    {
        var weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in this.WeaponsAllowed)
        {
            weapons.Add(weapon, null);
        }

        return weapons;
    }
}