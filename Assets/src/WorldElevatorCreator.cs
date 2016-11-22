using UnityEngine;
using System.Collections;

public class WorldElevatorCreator : WorldCreatorManager
{
    public WorldFloor worldFloorForElevator;
    public WorldFloor worldFloor;

    public override void OnCreateAt(Transform t)
    {
        WorldFloor worldFloor = t.gameObject.GetComponent<WorldFloor>();
        Vector3 pos = worldFloor.transform.position;
        worldCreator.EditorCreateWorldAsset(worldAsset, pos, Vector3.zero);
        pos.y += 2;
        World.Instance.creator.EditorCreateWorldAsset(worldFloorForElevator, pos, Vector3.zero);
        pos.x += 3;
        World.Instance.creator.EditorCreateWorldAsset(worldFloor, pos, Vector3.zero);
    }
}
