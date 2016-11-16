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
    void Update()
    {
        if(transform.localPosition.y<-10)
        {
            transform.localPosition = new Vector3(0, 1, 0);
            Idle();
        }
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
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.transform.gameObject.GetComponent<WorldWall>())
            Idle();
    }
    void Idle()
    {
        moveToTarget.SetOff();
    }
    void ClickedOnScreen()
    {
        Ray ray = eyesCamera.ScreenPointToRay(Input.mousePosition);
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
                        moveToTarget.SetOn(hit.point);
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
            }
        }         
    }
}
