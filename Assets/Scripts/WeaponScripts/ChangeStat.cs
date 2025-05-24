using UnityEngine;

public class ChangeStat : MonoBehaviour
{
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeStatInput(string Stat, float Value)
    {
        if (Input.GetKeyDown(KeyCode.F))
            GeneralStats.Instance.ModifyStat(Stat, Value);
    }
}
