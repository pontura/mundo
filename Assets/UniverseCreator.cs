using UnityEngine;
using System.Collections;

public class UniverseCreator : MonoBehaviour
{

    public Transform container;
    public Planet planet;
    public float aristaSize;
    public float totalPlanetsRow;
    private Vector3 offset;

    void Start()
    {
        for (int a = 0; a < totalPlanetsRow; a++)
            for (int b = 0; b < totalPlanetsRow; b++)
                for (int c = 0; c < totalPlanetsRow; c++)
                    CreateCube(new Vector3(a * aristaSize, b * aristaSize, c * aristaSize));
    }
    void CreateCube(Vector3 offset)
    {
        this.offset = offset;
        float _z = 0;
        //centro-abajo-frente
        CreateNewPlanet(new Vector3(0, -aristaSize / 2, _z)     ,           new Vector3(0,0,90));
        //izquierda-centro-frente
        CreateNewPlanet(new Vector3(-aristaSize / 2, 0, _z),                new Vector3(0, 0, 0));

        _z = aristaSize / 2;
        //izquierda-abajo-medio
        CreateNewPlanet(new Vector3(-aristaSize / 2, -aristaSize / 2, _z),  new Vector3(0, 90, 90));
    }
    void CreateNewPlanet(Vector3 pos, Vector3 rot)
    {
        Planet newPlanet = Instantiate(planet);
        newPlanet.transform.position = pos + offset;
        newPlanet.transform.localEulerAngles = rot;
        newPlanet.transform.SetParent(container);
    }
}
