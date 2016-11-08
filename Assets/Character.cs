using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{

    public GameObject eyes;
    public Camera eyesCamera;

    public MoveToTarget moveToTarget;
    public RotateByDrag rotateByDrag;
    public InputManager inputManager;

    void Start()
    {
        moveToTarget = GetComponent<MoveToTarget>();
        inputManager = GetComponent<InputManager>();
        rotateByDrag = GetComponent<RotateByDrag>();

        moveToTarget.enabled = false;
        Events.ClickedOnScreen += ClickedOnScreen;
        Events.OnDragging += OnDragging;
    }
    void OnDestroy()
    {
        Events.ClickedOnScreen -= ClickedOnScreen;
        Events.OnDragging -= OnDragging;
    }
    void OnDragging(bool dragging)
    {
        if (dragging)
        {
            moveToTarget.HasDragged();
            rotateByDrag.SetOn();
        }
        else
            rotateByDrag.SetOff();
    }
    void ClickedOnScreen()
    {
        RaycastHit hit;
        Ray ray = eyesCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Data.Instance.state == Data.states.MOVING)
            {
                if (hit.transform.gameObject.GetComponent<WorldFloor>())
                    moveToTarget.SetOn(hit.point);
            }
            else
            {
                Events.OnEditorRaycastHit(hit.transform);
            }  
        }            
    }
}
