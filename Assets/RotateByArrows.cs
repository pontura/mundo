using UnityEngine;
using System.Collections;

public class RotateByArrows : MonoBehaviour {

    public float speed = 50;
    InputManager inputManager;
    public UI_Planets ui_planets;
    public Transform target;
    private CharacterActions actions;

    void Start () {
        inputManager = GetComponent<InputManager>();
        actions = GetComponent<CharacterActions>();
    }	
	void Update () {
	    if(inputManager.forward!=0)
        {
            actions.Walk();
            transform.Rotate(Vector3.right * (Time.deltaTime * (speed)) );
        }
        else
        {
            actions.Idle();
        }
        if(ui_planets.direction != 0)
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * (speed)*15) * ui_planets.direction);
        }
    }
}
