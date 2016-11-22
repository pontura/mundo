using UnityEngine;
using System.Collections;

public class WorldWall : WorldAsset
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
    public void SetCorner(PlatformEditorData.parts part)
    {
        editingObjects[0].GetComponent<PlatformEditorData>().part = part;
    }
}
