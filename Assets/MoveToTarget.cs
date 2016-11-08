using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour {

    public GameObject target;
    private float speed = 1.5f;
    private float damping = 1.3f;
    private bool hasDragged;
    public CharacterModel characterModel;
    public Transform cameraTarget;

    public void SetOn(Vector3 pos)
    {
        enabled = true;
        ChangeTarget(pos);
        characterModel.Walk();
    }
    public void SetOff()
    {
        enabled = false;
        hasDragged = false;
        characterModel.Idle();
    }
    public void HasDragged()
    {
        hasDragged = true;
    }
    public void ChangeTarget(Vector3 newPos)
    {
        hasDragged = false;
        target.transform.position = newPos;
    }

    public float angle = 0.0F;
    public Vector3 axis = Vector3.forward;

    void Update () {
        if (Vector3.Distance(transform.localPosition, target.transform.position) > 0.5f)
        {
            Vector3 newPos = target.transform.position;
            characterModel.transform.LookAt(newPos);
            characterModel.transform.localEulerAngles = new Vector3(0,characterModel.transform.localEulerAngles.y, 0);
            transform.position = Vector3.MoveTowards(transform.localPosition, target.transform.position, speed * Time.deltaTime);
            if (!hasDragged)
            { 
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);


                Vector3 rot = cameraTarget.transform.localEulerAngles;
                //if (rot.y < 0) rot.y = 360 - rot.y;
                rot.y = Mathf.LerpAngle(rot.y, 0, Time.deltaTime);
                cameraTarget.transform.localEulerAngles = rot;
            }
        }
        else
        {
            SetOff();
        }
	}
   
}
