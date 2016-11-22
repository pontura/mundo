using UnityEngine;
using System.Collections;

public class WorldRoom : WorldAsset {

    public Material defaultPlaneMaterial;
    public Material editorMaterial;
    public WorldPlane[] planes;

    public override void OnStart()
    {
        OnEditModeDone(WorldCreator.EditingType.NONE);
        OnEditModeDone(World.Instance.creator.editingType);
    }
    public override void OnEditModeDone(WorldCreator.EditingType type)
    {
        foreach (WorldPlane plane in planes)
        {
            plane.SwitchMode(type);
        }
    }

}
