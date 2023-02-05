using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton;
   [SerializeField] public Animator animator;
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
        startButton.gameObject.SetActive(false);
        startButton.onClick.RemoveListener(StartGame);
    }
}