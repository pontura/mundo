using UnityEngine;
using System.Collections;

public class WorldCreator : MonoBehaviour {

    public WorldAsset worldFloor;
    public WorldAsset worldWall;
    public WorldAsset worldRoom;

    public Transform roomContainer;

    public EditingType editingType;
    public enum EditingType
    {
        NONE,
        FLOORS,
        WALLS
    }

    void Start() {
        CreateWorld();
        Events.OnEditmode += OnEditmode;
        Events.OnEditorRaycastHit += OnEditorRaycastHit;
    }
    void OnDestroy()
    {
        Events.OnEditmode -= OnEditmode;
        Events.OnEditorRaycastHit -= OnEditorRaycastHit;
    }
    void OnEditmode(EditingType type)
    {
        this.editingType = type;
        if (type == EditingType.FLOORS)
            UpdateWorldFloorCorners();
        if (type == EditingType.WALLS)
            ShowAllCorners();
    }
    void CreateWorld()
    {
        WorldAsset newWorldAsset = Instantiate(worldFloor);
        newWorldAsset.transform.SetParent(roomContainer);
        newWorldAsset.transform.localPosition = Vector3.zero;
    }
    void OnEditorRaycastHit(Transform t)
    {
        print(t);
        if (t.gameObject.GetComponent<PlatformEditor>())
        {
            PlatformEditor platformEditor = t.gameObject.GetComponent<PlatformEditor>();
            WorldFloor worldFloor = platformEditor.GetComponentInParent<WorldFloor>();
            if (worldFloor == null) return;
            switch(editingType)
            {
                case EditingType.FLOORS:
                    CheckToCreateFloor(worldFloor, platformEditor);
                    break;
                case EditingType.WALLS:
                    CheckToCreateWall(platformEditor);
                    break;
            }            
        }
    }
    void CheckToCreateWall(PlatformEditor platformEditor)
    {
        Vector3 pos = platformEditor.transform.position;
        Vector3 rot = Vector3.zero;
        if(platformEditor.part == PlatformEditor.parts.LEFT || platformEditor.part == PlatformEditor.parts.RIGHT)
            rot.y = 90;
        EditorCreateWorldAsset(worldWall, pos, rot);
    }
        
    void CheckToCreateFloor(WorldFloor worldFloor, PlatformEditor platformEditor)
    {
        Vector3 pos = worldFloor.transform.position;
        switch (platformEditor.part)
        {
            case PlatformEditor.parts.FRONT: pos.z += 3; break;
            case PlatformEditor.parts.BACK: pos.z -= 3; break;
            case PlatformEditor.parts.LEFT: pos.x -= 3; break;
            case PlatformEditor.parts.RIGHT: pos.x += 3; break;
        }
        if (!GetWorldAssetAt(worldFloor, roomContainer.GetComponentsInChildren<WorldFloor>(), pos))
        {
            EditorCreateWorldAsset(worldFloor, pos, Vector3.zero);
            UpdateWorldFloorCorners();
        }
    }
    void EditorCreateWorldAsset(WorldAsset worldAsset, Vector3 position, Vector3 rot)
    {
        WorldAsset newObject = Instantiate(worldAsset);
        newObject.transform.SetParent(roomContainer);
        newObject.transform.localPosition = position;
        newObject.transform.localEulerAngles = rot;
    }
    bool GetWorldAssetAt(WorldAsset exception, WorldAsset[] worldAsset, Vector3 pos)
    {
        foreach (WorldAsset wordAsset in worldAsset)
        {
            if (exception.transform.localPosition != wordAsset.transform.localPosition)
            {
                if (Vector3.Distance(wordAsset.transform.localPosition, pos) < 1)
                {
                    return true;
                }
            }  
        }
        return false;
    }
    void UpdateWorldFloorCorners()
    {
        WorldFloor[] floors = roomContainer.GetComponentsInChildren<WorldFloor>();
        foreach (WorldFloor wordAsset in roomContainer.GetComponentsInChildren<WorldFloor>())
        {
            Vector3 pos = wordAsset.transform.localPosition;
            wordAsset.SetCorners(
                !GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x, pos.y, pos.z + 3)),
                !GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x, pos.y, pos.z -3 )),
                !GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x + 3, pos.y, pos.z)),
                !GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x - 3, pos.y, pos.z))
                );

        }
    }
    void ShowAllCorners()
    {
        WorldFloor[] floors = roomContainer.GetComponentsInChildren<WorldFloor>();
        foreach (WorldFloor wordAsset in roomContainer.GetComponentsInChildren<WorldFloor>())
            wordAsset.SetCorners(true, true, true, true);
    }
}
