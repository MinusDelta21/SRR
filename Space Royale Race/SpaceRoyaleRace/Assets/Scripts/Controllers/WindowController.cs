using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowController : MonoBehaviour
{
    [SerializeField] List<Button> buttons;
    [SerializeField] List<Canvas> canvas;

    int currentIndex;
    Canvas activeCanvas;
    Button activeButton;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        ActivateButton(buttons[currentIndex]);
        ActivateCanvas(canvas[currentIndex]);
    }

    public void ActiveWindow(int selectedIndex)
    {
        if(currentIndex != selectedIndex)
        {
            //Activate clicked Button and Canvas
            ActivateButton(buttons[selectedIndex]);
            ActivateCanvas(canvas[selectedIndex]);
            //Dectivate clicked Button and Canvas
            DeactivateButton(buttons[currentIndex]);
            DeactivateCanvas(canvas[currentIndex]);
            //Change current index
            currentIndex = selectedIndex;
        }
    }

    void ActivateButton(Button button)
    {
        if (button != activeButton)
        {
            button.GetComponentInChildren<Image>().color = Color.cyan;
            button.GetComponentInChildren<Text>().color = Color.cyan;
            activeButton = button;
        }
    }
    void ActivateCanvas(Canvas canvas)
    {
        if(canvas != activeCanvas)
        {
            canvas.gameObject.SetActive(true);
            activeCanvas = canvas;
        }
    }

    void DeactivateButton(Button button)
    {
        button.GetComponentInChildren<Image>().color = Color.white;
        button.GetComponentInChildren<Text>().color = Color.white;
    }
    void DeactivateCanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
    }
}
