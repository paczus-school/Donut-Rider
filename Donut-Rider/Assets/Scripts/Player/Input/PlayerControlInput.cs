public class PlayerControlInput : IInput
{
    private PlayerInput input;

    public PlayerControlInput(PlayerInput newInput, DonutController donutController)
    {
        input = newInput;

        input.Donut.Thrust.performed += ctx => donutController.Thrust();
        input.Donut.Thrust.canceled += ctx => donutController.EndThrust();
        input.Donut.Breake.performed += ctx => donutController.Brake(true);
        input.Donut.Breake.canceled += ctx => donutController.Brake(false);
        input.Donut.Jump.performed += ctx => donutController.Jump();
    }

    public void Enable()
    {
        input.Donut.Enable();
    }

    public void Disable()
    {
        input.Donut.Disable();
    }
}
