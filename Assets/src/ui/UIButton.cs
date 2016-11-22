using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButton : MonoBehaviour {

    public Text field;

    public void Init(string title) {
        field.text = title;
    }

}
