using UnityEngine;
using System.Collections;

public class WorldAsset : MonoBehaviour {

    public Transform[] editingObjects;

    void Start()
    {
        Events.OnEditmode += OnEditmode;
        OnStart();
    }
    void OnDestroy()
    {
        Events.OnEditmode -= OnEditmode;
    }
    void OnEditmode(bool isEditor)
    {
        if (isEditor)
            foreach (Transform t in editingObjects)
                t.gameObject.SetActive(true);
        else
            foreach (Transform t in editingObjects)
                t.gameObject.SetActive(false);

        OnEditModeDone(isEditor);
    }
    public virtual void OnStart() { }
    public virtual void OnEditModeDone(bool isEditor) { }
}
