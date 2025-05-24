using UnityEngine;
using UnityEngine.Events;

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
    public GameEvent Gameevent;

    private void Awake()
    {   if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
       
        GetStats();
        
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

    public void ModifyStat(string Stat, float Value)
    {
        switch (Stat)
        {
            case "Damage":
                { Damage += Value; Gameevent.TriggerEvent(); }
                break;
            case "FireRate":
                { FireRate += Value; Gameevent.TriggerEvent(); }
                break;
            case "AmmoClip":
                { AmmoClip += Value; Gameevent.TriggerEvent(); }
                break;
            case "ReloadSpeed":
                { ReloadSpeed += Value; Gameevent.TriggerEvent(); }
                break;
            case "Accuracy":
                { Accuracy += Value; Gameevent.TriggerEvent(); }
                break;
            case "BulletSize":
                { BulletSize += Value; Gameevent.TriggerEvent(); }
                break;
            case "Range":
                { Range += Value; Gameevent.TriggerEvent(); }
                break;
            default:
                Debug.LogWarning($"Stat '{Stat}' not found.");
                break;
        }
    }




}
