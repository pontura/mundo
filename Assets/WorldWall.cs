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
            case WorldCreator.EditingType.FLOORS: mat = editingFloorMaterial; break;
            case WorldCreator.EditingType.WALLS: mat = editingWallMaterial; break;
        }
        foreach (EditableWorldObject t in editingObjects)
            t.GetComponent<MeshRenderer>().material = mat;

    }
    public void SetCorners(bool front, bool back, bool right, bool left)
    {
        print("SetCorners" + front + back + right + left);

        editingObjects[0].SetState(front);
        editingObjects[1].SetState(back);
        editingObjects[2].SetState(right);
        editingObjects[3].SetState(left);
    }
}
