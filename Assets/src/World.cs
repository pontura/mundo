using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    static World mInstance = null;
    public WorldCreator creator;

    public static World Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
    }
    void Start()
    {
        creator = GetComponent<WorldCreator>();
    }
}
