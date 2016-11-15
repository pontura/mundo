using UnityEngine;
using System.Collections;

public class EditableWorldObject : MonoBehaviour {
    
    public void SetState(bool state)
    {
        if(state)
             GetComponent<MeshRenderer>().enabled = true;
        else
             GetComponent<MeshRenderer>().enabled = false;
    }
}
