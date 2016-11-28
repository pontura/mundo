using UnityEngine;
using System.Collections;

public class RotateByDrag : MonoBehaviour {

    public InputManager inputManager;
    private float speed = 20;
    public Transform target;
    public Transform target_in_out_camera;
    public Transform target_in_subjective_camera;

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
            if (target == target_in_out_camera)
                newRot.x += (inputManager.updateDraggingPosition.y / speed);
            else
            {
                Vector3 newRot_cam = target_in_out_camera.localEulerAngles;
                newRot_cam.x += (inputManager.updateDraggingPosition.y / speed);
                SetRotation(target_in_out_camera, newRot_cam);
            }

            newRot.y -= (inputManager.updateDraggingPosition.x / speed);
            
            SetRotation(target.transform, newRot);
        }
    }
    public void SetTarget(CharacterEyesCamera.states state)
    {
        switch(state)
        {
            case CharacterEyesCamera.states.OUT:
                target = target_in_out_camera;
                break;
            case CharacterEyesCamera.states.SUBJECTIVE:
                target = target_in_subjective_camera;
                break;
        }
    }
    void SetRotation(Transform tr, Vector3 rot)
    {
        tr.localEulerAngles = rot;
    }
}
