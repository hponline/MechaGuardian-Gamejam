using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    Vector2 moveInput = Vector2.zero;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();

        playerInput.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        playerInput.Player.Attack.performed += OnAttack;
        playerInput.Player.Skills.performed += OnShieldSkill;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
        playerInput.Player.Attack.performed -= OnAttack;
        playerInput.Player.Skills.performed -= OnShieldSkill;
    }

    public Vector2 GetMoveDirection()
    {
        return moveInput;
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton())
        {
            PlayerCombat.instance.PlayerAttack();
            PlayerCombat.instance.PlayerLaserAttack();
            Debug.Log("Shooter/Laser ateþlendi");
        }
    }

    public void OnShieldSkill(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        PlayerCombat.instance.PlayerUseShield();
    }
}
