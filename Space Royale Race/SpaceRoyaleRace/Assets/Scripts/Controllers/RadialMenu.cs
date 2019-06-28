using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;
    public bool open;
    float angle;
    [SerializeField]float radius;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
        }
        open = false;

        angle = (360 / buttons.Count) * Mathf.Deg2Rad;
        float posX = 0.0f;
        float posY = 0.0f;
        for(int i = 0; i < buttons.Count; i++)
        {
            posX = Mathf.Cos(angle * i) * radius + transform.position.x;
            posY = Mathf.Sin(angle * i) * radius + transform.position.y;
            buttons[i].transform.position = new Vector3(posX, posY, 0);
        }
    }

    public void ShowMenu()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (open)
            {
                for (int i =0; i< buttons.Count;i++)
                {
                    buttons[i].SetActive(false);
                }
                open = false;
            }
            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].SetActive(true);
                }
                open = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        ShowMenu();
    }
}
