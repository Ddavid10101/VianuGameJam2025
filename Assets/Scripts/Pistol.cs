using UnityEngine;

public class Pistol : Weapon
{
    public Stats stats;
    

    private void Awake()
    {
        SetStats();
    }
    private void Update()
    {
       
       ManualWeaponLogic();
    }
}
