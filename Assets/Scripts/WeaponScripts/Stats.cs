using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Stats")]
public class Stats : ScriptableObject
{
    public float Damage;
    public float FireRate;
    public float AmmoClip;
    public float ReloadSpeed;
    public float Accuracy;
    public float BulletSize;
    public float Range;
    public GameObject BulletPrefab;
}
