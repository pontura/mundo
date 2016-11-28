using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISwitchButton : MonoBehaviour {

    public string[] states;
    public int id = 0;
    public Text field;
    private System.Action<int> action;

    void Start()
    {
        SetField(id);
    }
    public void Init(System.Action<int> action) {
        this.action = action;
    }
    public void Switch()
    {
        id++;
        if (id + 1 > states.Length) id = 0;
        SetField(id);
        action(id);
    }
    void SetField(int id)
    {
        field.text = states[id];
    }
}
