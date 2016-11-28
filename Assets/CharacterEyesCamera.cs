using UnityEngine;
using System.Collections;
using System;

public class CharacterEyesCamera : MonoBehaviour {

    [Serializable]
    public class CameraSettings
    {
        public Vector3 pos;
        public Vector3 rot;
        public Vector3 pivotPos;
        public Vector3 pivotRot;
    }
    public CameraSettings actualView;

    private CameraSettings outView;
    private CameraSettings subjectiveView;

    public GameObject pivot;
    public Camera mainCamera;
    public states state;
    public GameObject eyeAreaCollision;

    float timeToUpdate = 0.3f;
    float now;

    public enum states
    {
        OUT,
        SUBJECTIVE
    }
	void Start () {
        outView = new CameraSettings();
        outView.pos = new Vector3(0, 3.5f, -4.14f);
        outView.rot = new Vector3(25, 0,0);
        outView.pivotPos = Vector3.zero;
        outView.pivotRot = Vector3.zero;

        subjectiveView = new CameraSettings();
        subjectiveView.pos = new Vector3(0, 0, 0.5f);
        subjectiveView.rot = new Vector3(25, 0, 0);
        subjectiveView.pivotPos = new Vector3(0,1.25f,0);
        subjectiveView.pivotRot = Vector3.zero;
        
        SetState();
    }
    public void CameraChangeView(states _state)
    {
        this.state = _state;
        SetState();
    }
    
    void SetState()
    {
        switch(state)
        {
            case states.OUT:  actualView = outView; eyeAreaCollision.SetActive(true); break;
            case states.SUBJECTIVE: actualView = subjectiveView; eyeAreaCollision.SetActive(false); break;
        }
        now = 0;
    }
    void Update()
    {
        now += Time.deltaTime;
        if (now > timeToUpdate) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, actualView.pos, timeToUpdate);
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, actualView.rot, timeToUpdate);
        pivot.transform.localPosition = actualView.pivotPos;
        pivot.transform.localEulerAngles = actualView.pivotRot;
    }
}
