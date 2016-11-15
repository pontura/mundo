using UnityEngine;
using System.Collections;

public class PlatformEditor : EditableWorldObject {

    public parts part;
    public enum parts
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT
    }
}
