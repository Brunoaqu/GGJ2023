using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] private PathCreator game;
    [SerializeField] public Animator animator;
    public Button startButton;
    public AudioSource mainTheme;
    public AudioSource menuTheme;
    public float speed = 2;

    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(() => StartGame());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        animator.Play("Float", 0, 0.0f);
        menuTheme.Stop();
        mainTheme.Play();
        startButton.gameObject.SetActive(false);
        startButton.onClick.RemoveListener(StartGame);

        game.Draw(game.RandomMazeGenerator(5, 5, new Vector2Int(0,0), new Vector2Int(2,4)));
    }
}