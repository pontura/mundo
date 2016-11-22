using UnityEngine;
using System.Collections;

public class WorldCreatorManager : MonoBehaviour {

    public WorldAsset worldAsset;
    [HideInInspector]
    public WorldCreator worldCreator;

    void Start()
    {
        worldCreator = GetComponent<WorldCreator>();
    }

    public void CreateAt(Transform t)  {  OnCreateAt(t);  }
    public virtual void OnCreateAt(Transform t)   { }
}
