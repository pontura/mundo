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
        if (type != WorldCreator.EditingType.NONE)
            foreach (EditableWorldObject t in editingObjects)
                t.gameObject.SetActive(true);
        else
            foreach (EditableWorldObject t in editingObjects)
                t.gameObject.SetActive(false);

        OnEditModeDone(type);
    }
    public virtual void OnStart() { }
    public virtual void OnEditModeDone(WorldCreator.EditingType type) { }
}
