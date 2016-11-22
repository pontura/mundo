using UnityEngine;
using System.Collections;

public class WorldFloorCreator : WorldCreatorManager
{
    public void OnCreateWorld()
    {
        worldCreator.EditorCreateWorldAsset(worldAsset, Vector3.zero, Vector3.zero);
    }
    public override void OnCreateAt(Transform t)
    {
        PlatformEditorData platformEditor = t.gameObject.GetComponent<PlatformEditorData>();
        WorldFloor worldFloorSelected = platformEditor.GetComponentInParent<WorldFloor>();

        if (worldFloorSelected == null) return;

        Vector3 pos = worldFloorSelected.transform.position;

        switch (platformEditor.part)
        {
            case PlatformEditorData.parts.FRONT: pos.z += 3; break;
            case PlatformEditorData.parts.BACK: pos.z -= 3; break;
            case PlatformEditorData.parts.LEFT: pos.x -= 3; break;
            case PlatformEditorData.parts.RIGHT: pos.x += 3; break;
        }
        if (!worldCreator.GetWorldAssetAt(worldAsset, worldCreator.roomContainer.GetComponentsInChildren<WorldFloor>(), pos))
        {
            worldFloorSelected.SetCorner(platformEditor, false);
            worldCreator.EditorCreateWorldAsset(worldAsset, pos, Vector3.zero);
            worldCreator.AddConstructAnim(pos, platformEditor);
        }
    }
}
