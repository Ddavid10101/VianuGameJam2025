using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{   //Base Parameters
    public float Damage;
    public float FireRate;//
    public float AmmoClip;//
    public float ReloadSpeed;//
    public float Accuracy;//
    public float BulletSize;
    public float Range;//
    public GameObject BulletPrefab;
    //Specific Parameters
    public float CurrentAmmo;
    public bool CanFire;
    public bool FireCooldown;
    public Quaternion PlayerRotation;
    public GameObject PlayerObject, WeaponObject;

  

    

    protected void SetStats()
    {
        this.Damage = GeneralStats.Instance.Damage;
        this.FireRate = GeneralStats.Instance.FireRate;
        this.AmmoClip = GeneralStats.Instance.AmmoClip;
        this.ReloadSpeed = GeneralStats.Instance.ReloadSpeed;
        this.Accuracy = GeneralStats.Instance.Accuracy;
        this.BulletSize = GeneralStats.Instance.BulletSize;
        this.Range = GeneralStats.Instance.Range;
        this.BulletPrefab = GeneralStats.Instance.BulletPrefab;
        PlayerObject = GameObject.Find("Player");
        WeaponObject = GameObject.Find("Weapon");
        CurrentAmmo = AmmoClip;
    }

    protected void UpdateStats()
    {
        this.Damage = GeneralStats.Instance.Damage;
        this.FireRate = GeneralStats.Instance.FireRate;
        this.AmmoClip = GeneralStats.Instance.AmmoClip;
        this.ReloadSpeed = GeneralStats.Instance.ReloadSpeed;
        this.Accuracy = GeneralStats.Instance.Accuracy;
        this.BulletSize = GeneralStats.Instance.BulletSize;
        this.Range = GeneralStats.Instance.Range;
        this.BulletPrefab = GeneralStats.Instance.BulletPrefab;
    }
    protected void ReloadWeapon()
    {
        StartCoroutine("Reload");
    }

    protected virtual void FireWeapon(Transform SpawnPoint,Quaternion Rotation)
    {
        Vector3 EulerRotation = Rotation.eulerAngles;
        EulerRotation.z += RandomAngle(10, Accuracy);
        Quaternion NewRotation = Quaternion.Euler(EulerRotation);
        Instantiate(BulletPrefab, SpawnPoint.position, NewRotation);
        Debug.Log(RandomAngle(10, Accuracy));
    }
    

    

    private IEnumerator Reload()
    {
        CurrentAmmo = 0;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(ReloadSpeed);
        CurrentAmmo = AmmoClip;
    }

    protected bool AutoWeaponLogic()
    {
        if (Input.GetMouseButton(0))
            return true;
        return false;
    }

    protected void ManualWeaponLogic()
    {   
        PlayerRotation = RememberPlayerRotation(PlayerObject);
        CheckForFireManual();
        CheckForReload();
        if (CanFire)
        {
            FireWeapon(WeaponObject.transform,PlayerRotation);
            StartCoroutine("FireRateCooldown");
            CanFire = false;
            --CurrentAmmo;
        }
       
    }

    private void CheckForFireManual()
    {
        if (Input.GetMouseButtonDown(0) && CurrentAmmo> 0 && !FireCooldown)
            CanFire = true;
        else
            CanFire = false;
    }

    private void CheckForReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ReloadWeapon();
    }

    private IEnumerator FireRateCooldown()
    {
        FireCooldown = true;
        yield return new WaitForSeconds(FireRate);
        FireCooldown = false;
    }

    private Quaternion RememberPlayerRotation(GameObject gameObject)
    {
        return gameObject.transform.rotation;
    }

    private float RandomAngle(float MaxAngle,float Accuracy)
    {
        float RandomNumber = Random.Range(Accuracy, 100);
        int RandomSign = Random.Range(-1, 3);
        if (RandomSign == 0)
            RandomSign = -1;
        return MaxAngle * ((100 -  RandomNumber)/100)* Mathf.Sign(RandomSign);
    }
}
