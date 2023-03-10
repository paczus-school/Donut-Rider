using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private DebugMyText debugMyText;
    [SerializeField] private GameController gameController;

    private DonutController donutController;

    private PlayerInput playerInput;
    private GlobalInput globalInput;
    private InGameGeneralInput inGameGeneralInput;
    private PlayerControlInput playerControlInput;

    private Dictionary<string, IInput> inputs;

    private void Awake()
    {
        inputs = new Dictionary<string, IInput>();

        playerInput = new PlayerInput();
        globalInput = new GlobalInput(playerInput, gameController);
        inGameGeneralInput = new InGameGeneralInput(playerInput, gameController);
        inputs.Add("InGameGeneralInput", inGameGeneralInput);

        donutController = GameObject.FindGameObjectWithTag("Player").GetComponent<DonutController>();
        playerControlInput = new PlayerControlInput(playerInput, donutController);
        inputs.Add("PlayerControlInput", playerControlInput);

        //globalInput.Enable();
        playerControlInput.Enable();
        inGameGeneralInput.Enable();
    }

    public void DisableInput(string inputName)
    {
        inputs[inputName].Disable();
    }

    public void EnableInput(string inputName)
    {
        inputs[inputName].Enable();
    }
}
