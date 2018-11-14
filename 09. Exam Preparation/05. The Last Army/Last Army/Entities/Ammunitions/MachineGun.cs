public class MachineGun : Ammunition
{
    private const double MACHINE_GUN_WEIGHT = 10.6;

    public MachineGun()
        : base(nameof(MachineGun), MACHINE_GUN_WEIGHT)
    {
    }
}