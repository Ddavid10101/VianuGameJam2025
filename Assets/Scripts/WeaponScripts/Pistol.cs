using UnityEngine;

public class Pistol : Weapon
{
   
    

    private void Start()
    {
        SetStats();
    }
    private void Update()
    {
       
       ManualWeaponLogic();
    }
}
