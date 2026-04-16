using UnityEngine;
using UnityEngine.InputSystem;
public class AgentController : MonoBehaviour
{
    public Vector2 moveValue;
    public float runValue;

    InputAction moveAction;
    InputAction runAction;
    InputAction JumpAction;
    public bool jumpPressed;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        runAction = InputSystem.actions.FindAction("Sprint");
        JumpAction = InputSystem.actions.FindAction("Jump");

        moveAction.Enable();
        runAction.Enable();
        JumpAction.Enable();


    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        runValue = runAction.ReadValue<float>();
        jumpPressed = JumpAction.WasPressedThisFrame(); // evita saltos infinitos

    }
}
