using UnityEngine;
using System.Collections;

public class UI_Planets : MonoBehaviour {

    public int direction;
    public InputManager inputManager;

    void Start () {
    }

    public void OnDown(int id)
    {
        switch (id)
        {
            case 1:
                direction = -1;
                break;
            case 2:
                direction = 1;
                break;
            case 3:
                inputManager.forward = 1;
                break;
        }
    }
    public void OnUp(int id)
    {
        print("onUp" + id);
        if(id==3)
        {
            inputManager.forward = 0;
        } else
            direction = 0;
    }
}
