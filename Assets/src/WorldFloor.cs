using UnityEngine;
using System.Collections;

public class WorldFloor : WorldAsset
{

    public override void OnStart()
    {
        Events.OnEditmode += OnEditmode;
    }
    void OnDestroy()
    {
        Events.OnEditmode -= OnEditmode;
    }
    void OnEditmode(WorldCreator.EditingType type)
    {
        Material mat = null;
        switch (type)
        {
            case WorldCreator.EditingType.FLOORS: mat = World.Instance.creator.editingFloorMaterial; break;
            case WorldCreator.EditingType.WALLS: mat = World.Instance.creator.editingWallMaterial; break;
        }
        foreach (EditableWorldObject t in editingObjects)
            t.GetComponent<MeshRenderer>().material = mat;

    }
    public void SetCorners(bool front, bool back, bool right, bool left)
    {
        if (editingObjects.Length == 0) return;
        editingObjects[0].SetState(front);
        editingObjects[1].SetState(back);
        editingObjects[2].SetState(right);
        editingObjects[3].SetState(left);
    }
    public void SetCorner(PlatformEditorData platformEditor, bool showIt)
    {
        switch (platformEditor.part)
        {
            case PlatformEditorData.parts.FRONT: editingObjects[0].SetState(showIt); break;
            case PlatformEditorData.parts.BACK: editingObjects[1].SetState(showIt); break;
            case PlatformEditorData.parts.LEFT: editingObjects[3].SetState(showIt); break;
            case PlatformEditorData.parts.RIGHT: editingObjects[2].SetState(showIt); break;
        }
    }
}
