using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    public float Damage;
    public float FireRate;
    public float AmmoClip;
    public float ReloadSpeed;
    public float Accuracy;
    public float BulletSize;
    public float Range;
    public Stats stats;
    public GameObject BulletPrefab;
    public static GeneralStats Instance;

    private void Awake()
    {
        GetStats();
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void GetStats()
    {
        Damage = stats.Damage;
        FireRate = stats.FireRate;
        AmmoClip = stats.AmmoClip;
        ReloadSpeed = stats.ReloadSpeed;
        Accuracy = stats.Accuracy;
        BulletSize= stats.BulletSize;
        Range = stats.Range;
        BulletPrefab = stats.BulletPrefab;
    }


}
