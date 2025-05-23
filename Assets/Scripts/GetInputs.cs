using UnityEngine;

public class GetInputs
{
    public Vector2 GetAxisInputs()
    {
        float XAxis = Input.GetAxisRaw("Horizontal");
        float YAxis = Input.GetAxisRaw("Vertical");
        return new Vector2(XAxis, YAxis);
    }

    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
