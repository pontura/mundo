using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public CharacterEyesCamera eyesCamera;  
    public CharacterActions actions;
    public CharacterStates states;

    private RotateByDrag rotateByDrag;

    void Start()
    {
        actions = GetComponent<CharacterActions>();
        states = GetComponent<CharacterStates>();
        rotateByDrag = GetComponent<RotateByDrag>();

        CameraChangeView(CharacterEyesCamera.states.OUT);

        Events.ClickedOnScreen += ClickedOnScreen;
        Events.OnDragging += OnDragging;
        Events.CameraChangeView += CameraChangeView;
        Events.OnWalking += OnWalking;
    }
    void OnDestroy()
    {
        Events.ClickedOnScreen -= ClickedOnScreen;
        Events.OnDragging -= OnDragging;
        Events.CameraChangeView -= CameraChangeView;
        Events.OnWalking -= OnWalking;
    }
    void OnWalking(bool isWalking)
    {
        if (isWalking)
            GetComponent<InputManager>().forward = 1;
        else GetComponent<InputManager>().forward = 0;
    }
    void CameraChangeView(CharacterEyesCamera.states state)
    {
        eyesCamera.CameraChangeView(state);
        rotateByDrag.SetTarget(state);
    }
    void Update()
    {
        states.OnUpdate();
    }
    void OnDragging(bool dragging)
    {
        states.OnDragging(dragging);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.gameObject.GetComponent<WorldWall>())
            states.StopMoving();
    }
    void ClickedOnScreen()
    {
        Ray ray = eyesCamera.mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray.origin, ray.direction, 10f);
        
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            switch(World.Instance.creator.editingType)
            {
                case WorldCreator.EditingType.NONE:
                    if (hit.transform.gameObject.GetComponent<WorldFloor>())
                    {
                        states.ClickedOnScreen(hit);
                        return;
                    }
                    break;
                case WorldCreator.EditingType.FLOORS:
                    if(hit.transform.gameObject.name == "floor_corner")
                    {
                        Events.OnEditorRaycastHit(hit.transform);
                        return;
                    }
                    break;
                case WorldCreator.EditingType.WALLS:
                    if (hit.transform.gameObject.name == "floor_corner" || hit.transform.gameObject.name == "wall_corner")
                    {
                        Events.OnEditorRaycastHit(hit.transform);
                        return;
                    }
                    break;
                case WorldCreator.EditingType.ELEVATOR:
                    if (hit.transform.gameObject.GetComponent<WorldFloor>())
                    {
                        Events.OnEditorRaycastHit(hit.transform);
                        return;
                    }
                    break;
            }
        }         
    }
}
