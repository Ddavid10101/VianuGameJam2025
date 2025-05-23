using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    
    private Vector2 MoveVector;
    [Header("MoveParameters")]
    [SerializeField] float Speed;
    [SerializeField] private TargetRotate Rotation;
    private GetInputs InputManager;
    private Vector2 MousePosition;


    private void Awake()
    {
        
        Rotation = new TargetRotate(gameObject);
        InputManager = new GetInputs();
    }

    private void Update()
    {
        MoveVector = InputManager.GetAxisInputs();
        MousePosition = InputManager.GetMousePosition();
        Rotation.RotationTowardsTarget(MousePosition);
        UseInput();
    } 

   


   private void UseInput()
    {
        transform.Translate(MoveVector * Speed * Time.deltaTime, Space.World);
    }
    
}
