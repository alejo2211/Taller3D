using UnityEngine;
using UnityEngine.InputSystem;
public class AgentController : MonoBehaviour
{
    public Vector2 moveValue;
    public float runValue;

    InputAction moveAction;
    InputAction runAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        runAction = InputSystem.actions.FindAction("Sprint");

    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        runValue = runAction.ReadValue<float>();
    }
}
