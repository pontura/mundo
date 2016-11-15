using UnityEngine;
using System.Collections;

public class WorldPlane : MonoBehaviour {

    public parts part;
    public enum parts
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT,
        ROOF,
        FLOOR
    }
    public Material material;
    public Material editingMaterialFloor;
    public Material editingMaterialWalls;
    public MeshRenderer outPlane;
    public MeshRenderer inPlane;

    public void SwitchMode(WorldCreator.EditingType type)
    {
        switch (type)
        {
            case WorldCreator.EditingType.NONE:
                inPlane.enabled = true;
                outPlane.material = material;
                break;
            case WorldCreator.EditingType.FLOORS:
                inPlane.enabled = false;
                outPlane.material = editingMaterialFloor;
                break;
            case WorldCreator.EditingType.WALLS:
                inPlane.enabled = false;
                outPlane.material = editingMaterialWalls;
                break;
        }
    }
    public void SetMaterial (Material material) {
        inPlane.material = material;
        outPlane.material = material;
        this.material = material;
    }

}
