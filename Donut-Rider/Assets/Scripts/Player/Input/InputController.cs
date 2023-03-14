using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private DebugMyText debugMyText;
    [SerializeField] private GameController gameController;

    private DonutController donutController;

    private PlayerInput playerInput;
    private GlobalInput globalInput;
    private TestInput testInput;
    private PlayerControlInput playerControlInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        if(debugMyText)
            testInput = new TestInput(playerInput, debugMyText);
        if(gameController)
            globalInput = new GlobalInput(playerInput, gameController);

        donutController = GameObject.FindGameObjectWithTag("Player").GetComponent<DonutController>();
        playerControlInput = new PlayerControlInput(playerInput, donutController);

        //globalInput.Enable();
        playerControlInput.Enable();
    }

    public TestInput GetTestInput()
    {
        return testInput;
    }
}
