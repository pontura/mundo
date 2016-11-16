using UnityEngine;
using System.Collections;

public class WorldAsset : MonoBehaviour {

    public Material editingFloorMaterial;
    public Material editingWallMaterial;

    public EditableWorldObject[] editingObjects;

    void Start()
    {
        Events.OnEditmode += OnEditmode;
        OnStart();
    }
    void OnDestroy()
    {
        Events.OnEditmode -= OnEditmode;
    }
    void OnEditmode(WorldCreator.EditingType type)
    {
        if (type == WorldCreator.EditingType.NONE)
            foreach (EditableWorldObject t in editingObjects)
                t.gameObject.SetActive(false);
        else
        {
            foreach (EditableWorldObject t in editingObjects)
            {
                if (
                        (type == WorldCreator.EditingType.FLOORS && t.name == "floor_corner")
                        ||
                        (type == WorldCreator.EditingType.WALLS && t.name == "floor_corner")
                    )
                    t.gameObject.SetActive(true);
                else
                    t.gameObject.SetActive(false);
            }
        }
        OnEditModeDone(type);
    }
    void OnTriggerEnter(Collider other)
    {
        OnCameraHit(true);
    }
    void OnTriggerExit(Collider other)
    {
        OnCameraHit(false);
    }
    public virtual void OnStart() { }
    public virtual void OnCameraHit(bool hitted)
    {
        foreach (MeshRenderer r in GetComponentsInChildren<MeshRenderer>())
        {
            Color color = r.material.color;
            if (hitted)
                color.a = 0.5f;
            else
                color.a = 1;
            r.material.color = color;
        }
    }
    public virtual void OnEditModeDone(WorldCreator.EditingType type) { }
}
