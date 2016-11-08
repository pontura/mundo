using UnityEngine;
using System.Collections;

public class RotateByDrag : MonoBehaviour {

    public InputManager inputManager;
    private float speed = 20;
    public Transform target;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }
    public void SetOn() {
        enabled = true;
    }
    public void SetOff()
    {
        enabled = false;
    }
    void Update()
    {
        if (inputManager.updateDraggingPosition != Vector3.zero)
        {
            Vector3 newRot = target.transform.localEulerAngles;
            newRot.x  += (inputManager.updateDraggingPosition.y / speed);
            newRot.y -= (inputManager.updateDraggingPosition.x / speed);
            target.transform.localEulerAngles = newRot;
        }
    }
    
}
