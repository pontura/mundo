using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    Vector3 startPos;

    float heroRotation;
    float heroRotationVertical;

    public states state;
    private float time_start_pressing;

    public Vector3 updateDraggingPosition;
    private Vector3 lastMousePos;

    public enum states
    {
        IDLE,
        PRESSING,
        DRAGGING
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Release();
        if (Input.GetMouseButtonDown(0))
            Press();
        if (state == states.PRESSING)
        {
            if (time_start_pressing + 1 > Time.time)
                StartDragging();
        } else if(state == states.DRAGGING)
        {
            UpdateDragging();
        }
    }
    void Press()
    {
        bool overUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        if (overUI) return;
        startPos = Input.mousePosition;
        state = states.PRESSING;
        time_start_pressing = Time.time;
    }
    void Release()
    {
        lastMousePos = Vector3.zero;
        float distance = Vector3.Distance(startPos, Input.mousePosition);
        if (distance < 20) Events.ClickedOnScreen();
        state = states.IDLE;
        Events.OnDragging(false);
    }
    void StartDragging()
    {
        state = states.DRAGGING;
        Events.OnDragging(true);
    }
    void UpdateDragging()
    {
        if (lastMousePos != Vector3.zero)
            updateDraggingPosition = lastMousePos - Input.mousePosition;
        lastMousePos = Input.mousePosition;
    }
}
