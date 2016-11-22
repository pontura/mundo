using UnityEngine;
using System.Collections;

public class ConstructAnim : MonoBehaviour {

	public void Init(Vector3 pos, PlatformEditorData platformEditor, float timeToCreate)
    {
        int Y_degrees = 0;
        switch (platformEditor.part)
        {
            case PlatformEditorData.parts.FRONT: Y_degrees = 0; break;
            case PlatformEditorData.parts.BACK: Y_degrees = 180; break;
            case PlatformEditorData.parts.LEFT: Y_degrees = 270; break;
            case PlatformEditorData.parts.RIGHT: Y_degrees = 90; break;
        }
        transform.localPosition = pos;
        transform.localEulerAngles = new Vector3(0, Y_degrees, 0);
        Invoke("SetOff", timeToCreate);
    }
    void SetOff()
    {
        Destroy(gameObject);
    }
}
