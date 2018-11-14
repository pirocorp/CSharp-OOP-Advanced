using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly AmmunitionFactory ammunitionFactory;
    private readonly Dictionary<string, int> ammunitionQuantities;

    public WareHouse()
    {
        this.ammunitionQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmunitions(string name, int quantity)
    {
        if (!this.ammunitionQuantities.ContainsKey(name))
        {
            this.ammunitionQuantities[name] = 0;
        }

        this.ammunitionQuantities[name] += quantity;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var isEquipped = true;

        var missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        foreach (var weaponName in missingWeapons)
        {
            if (this.ammunitionQuantities.ContainsKey(weaponName) && this.ammunitionQuantities[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitionQuantities[weaponName]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }
}