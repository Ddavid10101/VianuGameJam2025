using UnityEngine;

public class TargetRotate 
{
    
    public GameObject Origin { get; private set; }

    public TargetRotate(GameObject Origin)
    {
        this.Origin = Origin;
    }
  

    public void RotationTowardsTarget(Vector3 TargetPosition)
    {
        float CurrentAngle = CalcAngle(TargetPosition - Origin.transform.position);
        RotateObject(CurrentAngle);
    }

    private float CalcAngle(Vector2 RelativePosition)
    {   
        return Mathf.Atan2(RelativePosition.y, RelativePosition.x) * Mathf.Rad2Deg;
    }

    private void RotateObject(float Angle)
    {
        Origin.transform.rotation = Quaternion.Euler(Vector3.forward * Angle);
    }
}
