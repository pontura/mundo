using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
    
    public GameObject selectedPanel;
    public GameObject interactivePanel;
    public UISwitchButton switchMode;
    
    void Start()
    {
        switchMode.Init(SwitchMode);
    }    
    public void Clicked(int id)
    {
        switch (id)
        {
            case 0:
                Events.OnEditmode(WorldCreator.EditingType.NONE);
                break;
            case 1:
                Events.OnEditmode(WorldCreator.EditingType.FLOORS);
                break;
            case 2:
                Events.OnEditmode(WorldCreator.EditingType.WALLS);
                break;
            case 3:
                Events.OnEditmode(WorldCreator.EditingType.ELEVATOR);
                break;
        }
        
    }
    public void Walk(bool isPressed)
    {
        Events.OnWalking(isPressed);
    }
    public void SwitchMode(int id)
    {
        print(id);
        if(id == 1)
            Events.CameraChangeView(CharacterEyesCamera.states.SUBJECTIVE);
        else
            Events.CameraChangeView(CharacterEyesCamera.states.OUT);
    }
}
