using UnityEngine;
using System.Collections;

public class PlatformEditorData : EditableWorldObject {

    public parts part;
    public enum parts
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT
    }
}
