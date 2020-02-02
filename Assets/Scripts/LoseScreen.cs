using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public static int highscore = 0;
    [SerializeField] private UnityEngine.UI.Text text;

    private void Start()
    {
        
    }

    private void Update()
    {
        text.text = "Highscore: " + highscore;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame
            || Gamepad.current != null && Gamepad.current.aButton.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
