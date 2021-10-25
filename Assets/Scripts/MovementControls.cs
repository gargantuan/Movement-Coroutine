using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControls : MonoBehaviour
{
    private PlayerControls playerControls;
    private Movement movement;
    private Rotation rotation;

    void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    void OnDisable()
    {
        playerControls.Gameplay.Disable();
    }

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.Movement.performed += OnMovementPerformed;
        movement = GetComponent<Movement>();
        rotation = GetComponent<Rotation>();
    }

    void OnMovementPerformed(InputAction.CallbackContext context)
    {
        if (!movement)
        {
            Debug.LogWarning("No movement script attacted to game object");
            return;
        }

        Vector2 controlVector = context.ReadValue<Vector2>();

        if (controlVector == Vector2.up)
        {
            movement.SetDirection(Vector3.forward);
            rotation.SetRotation(new Vector3(0, 0, 0));
        }

        if (controlVector == Vector2.down)
        {
            movement.SetDirection(Vector3.back);
            rotation.SetRotation(new Vector3(0, 180, 0));
        }

        if (controlVector == Vector2.left)
        {
            movement.SetDirection(Vector3.left);
            rotation.SetRotation(new Vector3(0, 270, 0));
        }

        if (controlVector == Vector2.right)
        {
            movement.SetDirection(Vector3.right);
            rotation.SetRotation(new Vector3(0, 90, 0));
        }

    }

    public void HandleEnemyCollision()
    {
        movement.SetDirection(Vector3.zero);
        rotation.SetRotation(Vector3.zero);
    }
}
