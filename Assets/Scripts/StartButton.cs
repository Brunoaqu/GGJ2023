using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button startButton;

    void Start()
    {
     
    }

    void TaskOnClick()
    {
        startButton.onClick.RemoveListener(TaskOnClick);
       
        startButton.gameObject.SetActive(false);
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

}