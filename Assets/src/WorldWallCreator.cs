using UnityEngine;
using System.Collections;

public class WorldWallCreator : WorldCreatorManager
{
    public override void OnCreateAt(Transform t)
    {
        PlatformEditorData platformEditor = t.gameObject.GetComponent<PlatformEditorData>();
        Vector3 pos = platformEditor.transform.position;
        Vector3 rot = Vector3.zero;
        if (platformEditor.part == PlatformEditorData.parts.LEFT || platformEditor.part == PlatformEditorData.parts.RIGHT)
            rot.y = 90;
        worldCreator.EditorCreateWorldAsset(worldAsset, pos, rot);
    }
}
