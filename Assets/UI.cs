using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
    
    public GameObject selectedPanel;
    public GameObject interactivePanel;

    

	void Start () {
        selectedPanel.SetActive(true);
        Close();
        Invoke("Close", 0.1f);
    }
    public void Open()
    {
        if(Data.Instance.state == Data.states.MOVING)
        {
            Data.Instance.state = Data.states.EDITING;
        }
        else
        {
            Data.Instance.state = Data.states.MOVING;
        }
        Close();
       // selectedPanel.SetActive(false);
       // interactivePanel.SetActive(true);
    }
    public void Close()
    {
        switch (Data.Instance.state)
        {
            case Data.states.MOVING:
                selectedPanel.GetComponentInChildren<UIButton>().Init("M");
                Events.OnEditmode(false);
                break;
            case Data.states.EDITING:
                selectedPanel.GetComponentInChildren<UIButton>().Init("E");
                Events.OnEditmode(true);
                break;
        }
        selectedPanel.SetActive(true);
        interactivePanel.SetActive(false);
    }
    public void Select(string s)
    {
        switch (s)
        {
            case "M": Data.Instance.state = Data.states.MOVING; break;
            case "E": Data.Instance.state = Data.states.EDITING; break;
        }
        Close();
    }

}
