using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputAction move;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        rb.AddForce( 5f * move.ReadValue<Vector2>() );
    }
}
