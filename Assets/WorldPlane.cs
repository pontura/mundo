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
    public Material editingMaterial;
    public MeshRenderer outPlane;
    public MeshRenderer inPlane;

    public void SetMaterials(Material material, Material editingMaterial)
    {
        this.material = material;
        this.editingMaterial = editingMaterial;
        SwitchMode(Data.Instance.state);
    }
    public void SwitchMode(Data.states state)
    {
        switch(state)
        {
            case Data.states.EDITING:
                inPlane.enabled = false;
                outPlane.material = editingMaterial;
                break;
            case Data.states.MOVING:
                inPlane.enabled = true;
                outPlane.material = material;
                break;
        }
    }
    public void SetMaterial (Material material) {
        inPlane.material = material;
        outPlane.material = material;
        this.material = material;
    }

}
