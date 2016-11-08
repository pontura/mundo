using UnityEngine;
using System.Collections;

public class WorldRoom : WorldAsset {

    public Material defaultPlaneMaterial;
    public Material editorMaterial;
    public WorldPlane[] planes;

    public override void OnStart()
    {
        OnEditModeDone(true);
        foreach (WorldPlane plane in planes)
        {
            plane.SetMaterials(defaultPlaneMaterial, editorMaterial);
        }
    }
    public override void OnEditModeDone(bool isEditing)
    {
        Data.states dataState = Data.Instance.state;
        foreach (WorldPlane plane in planes)
        {
            plane.SwitchMode(dataState);
        }
    }

}
