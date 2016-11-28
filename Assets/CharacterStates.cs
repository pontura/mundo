using UnityEngine;
using System.Collections;

public class CharacterStates : MonoBehaviour {

    public InputManager inputManager;
    private CharacterActions actions;
    private Character character;
    public MoveToTarget moveToTarget;
    public RotateByDrag rotateByDrag;

    void Start()
    {        
        inputManager = GetComponent<InputManager>();
        actions = GetComponent<CharacterActions>();
        character = GetComponent<Character>();
        Reset();
    }
	public void OnUpdate () {
        if (transform.localPosition.y < -10)
            Reset();
        if (character.eyesCamera.state == CharacterEyesCamera.states.SUBJECTIVE)
        {
            if (inputManager.forward > 0)
                actions.WalkStraight();
            else
            { }
                //StopMoving();
        }
    }
    void Reset()
    {
        moveToTarget.enabled = false;
        transform.localPosition = new Vector3(0, 0, 0);
        StopMoving();
    }
    public void OnDragging(bool dragging)
    {
        if (dragging)
        {
            moveToTarget.HasDragged();
            rotateByDrag.SetOn();
        }
        else
            rotateByDrag.SetOff();
    }
    public void ClickedOnScreen(RaycastHit hit)
    {
        if (character.eyesCamera.state != CharacterEyesCamera.states.SUBJECTIVE)
            moveToTarget.SetOn(hit.point);
    }
    public void StopMoving()
    {
        moveToTarget.SetOff();
        character.actions.Idle();
        character.actions.SetPhysics(true);
    }
}
