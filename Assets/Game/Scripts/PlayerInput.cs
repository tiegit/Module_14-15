using UnityEngine;

public class PlayerInput
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const KeyCode Restart = KeyCode.Return;
    private const KeyCode UseItem = KeyCode.F;

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public float MouseXInput { get; private set; }
    public bool RestartPressed { get; private set; }
    public bool UseItemPressed { get; private set; }

    public void CustomUpdate()
    {
        HorizontalInput = Input.GetAxisRaw(HorizontalAxis);
        VerticalInput = Input.GetAxisRaw(VerticalAxis);
        RestartPressed = Input.GetKeyDown(Restart);
        UseItemPressed = Input.GetKeyDown(UseItem);
    }
}
