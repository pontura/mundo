using UnityEngine;
using System.Collections;

public class WorldCreator : MonoBehaviour {

    public Material defaultMaterial;
    public Material defaultMaterial_SeeThrough;

    public Material editingFloorMaterial;
    public Material editingWallMaterial;

    public WorldAsset worldRoom;
    public ConstructAnim constructAnim;

    public WorldCreatorManager FloorsCreator;
    public WorldCreatorManager WallsCreator;
    public WorldCreatorManager ElevatorCreator;
    WorldCreatorManager actualCreator;

    public float timeToCreate = 0.25f;
    public Transform roomContainer;

    public EditingType editingType;
    public enum EditingType
    {
        NONE,
        FLOORS,
        WALLS,
        ELEVATOR
    }

    void Start() {
        Events.OnEditmode += OnEditmode;
        Events.OnEditorRaycastHit += OnEditorRaycastHit;

        FloorsCreator.GetComponent<WorldFloorCreator>().OnCreateWorld();
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
        else if (type == EditingType.WALLS)
            ShowAllCorners();
    }
    WorldCreatorManager GetCreator()
    {
        switch(editingType)
        {
            case EditingType.FLOORS: return FloorsCreator;
            case EditingType.WALLS: return WallsCreator;
            case EditingType.ELEVATOR: return ElevatorCreator;
        }
        return null;
    }
    void OnEditorRaycastHit(Transform t)
    {
        GetCreator().CreateAt(t);
    }        
    public void AddConstructAnim(Vector3 pos, PlatformEditorData platformEditor)
    {
        ConstructAnim newConstructAnim = Instantiate(constructAnim);
        newConstructAnim.Init(pos, platformEditor, timeToCreate);
        Invoke("UpdateWorldFloorCorners", timeToCreate + 0.1f);
    }
    public void EditorCreateWorldAsset(WorldAsset worldAsset, Vector3 position, Vector3 rot)
    {
        print("EditorCreateWorldAsset " + worldAsset);
        WorldAsset newObject = Instantiate(worldAsset);
        newObject.transform.SetParent(roomContainer);
        newObject.transform.localPosition = position;
        newObject.transform.localEulerAngles = rot;
        newObject.Init(timeToCreate);
    }
    public WorldAsset GetWorldAssetAt(WorldAsset exception, WorldAsset[] worldAsset, Vector3 pos)
    {
        foreach (WorldAsset wordAsset in worldAsset)
        {
            if (exception.transform.localPosition != wordAsset.transform.localPosition)
            {
                if (Vector3.Distance(wordAsset.transform.localPosition, pos) < 1)
                {
                    return wordAsset;
                }
            }  
        }
        return null;
    }
    void UpdateWorldFloorCorners()
    {
        WorldFloor[] floors = roomContainer.GetComponentsInChildren<WorldFloor>();
        foreach (WorldFloor wordAsset in roomContainer.GetComponentsInChildren<WorldFloor>())
        {
            Vector3 pos = wordAsset.transform.localPosition;
            wordAsset.SetCorners(
                GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x, pos.y, pos.z + 3)) == null,
                GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x, pos.y, pos.z -3 )) == null,
                GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x + 3, pos.y, pos.z)) == null,
                GetWorldAssetAt(wordAsset, floors, new Vector3(pos.x - 3, pos.y, pos.z)) == null
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
