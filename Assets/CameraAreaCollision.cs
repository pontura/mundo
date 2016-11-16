using UnityEngine;
using System.Collections;

public class CameraAreaCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
    }
}
