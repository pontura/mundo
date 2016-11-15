using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
    
    public GameObject selectedPanel;
    public GameObject interactivePanel;
    
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
        }
        
    }
}
