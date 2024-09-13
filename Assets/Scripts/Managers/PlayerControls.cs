using UnityEngine;

public static class PlayerControls
{
    private static Controls _controls;
    private static Player _player;

    public static void Init(Player player)
    {
        _controls = new Controls();
        _player = player;

        _controls.Player.Move.performed += ctx => _player.SetMoveDirection(ctx.ReadValue<Vector2>());

        _controls.Player.Look.performed += ctx => _player.SetLookDirection(ctx.ReadValue<Vector2>());

        _controls.Player.Interact.performed += ctx => _player.SetInteractionState(ctx.ReadValueAsButton());

        _controls.Player.Jump.performed += _ => _player.Jump(); 
    }

    public static void EnableGame()
    {
        _controls.Player.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

