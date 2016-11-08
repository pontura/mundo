using UnityEngine;
using System.Collections;

public class WorldCreator : MonoBehaviour {

    public WorldAsset worldFloor;
    public WorldAsset worldRoom;
    public Transform roomContainer;

    void Start() {
        CreateWorld();
        Events.OnEditorRaycastHit += OnEditorRaycastHit;
    }
    void OnDestroy()
    {
        Events.OnEditorRaycastHit -= OnEditorRaycastHit;
    }
    void CreateWorld()
    {
        int totalQty = 10;
        int size = 3;
        Vector3 pos = Vector3.zero;
        for (int a = 0; a < 10; a++)
            for (int b = 0; b < 10; b++)
            {
                WorldAsset newWorldAsset = Instantiate(worldFloor);
                newWorldAsset.transform.SetParent(roomContainer);
                newWorldAsset.transform.localPosition = new Vector3(a * size, 0, b * size);
            }
        roomContainer.transform.localPosition = new Vector3(-size * totalQty / 2, 0, -size * totalQty / 2);
    }
    void OnEditorRaycastHit(Transform t)
    {
        if (t.gameObject.GetComponent<WorldFloor>())
        {
            WorldFloor worldFloor = t.gameObject.GetComponent<WorldFloor>();
            EditorCreateRoom(worldFloor.transform.localPosition);
        }
        else if (t.gameObject.GetComponent<WorldRoom>())
        {
            WorldRoom worldRoom = t.gameObject.GetComponent<WorldRoom>();
            GameObject.Destroy(worldRoom.gameObject);
        }
    }
    void EditorCreateRoom(Vector3 position)
    {
        WorldAsset newWorldAsset = Instantiate(worldRoom);
        newWorldAsset.transform.SetParent(roomContainer);
        newWorldAsset.transform.localPosition = position;
    }
}
