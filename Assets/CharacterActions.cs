using UnityEngine;
using System.Collections;

public class CharacterActions : MonoBehaviour {

    public CharacterModel model;
    private float speed = 2;


    public void Walk()
    {
        model.Walk();
        GetComponent<Rigidbody>().isKinematic = false;
        SetPhysics(true);
    }
    public void Idle()
    {
        model.Idle();
        print("Idle");
        SetPhysics(false, 0.1f);
    }
    public void WalkStraight()
    {
        Vector3 FORWARD = model.transform.TransformDirection(Vector3.forward);
        transform.localPosition += FORWARD * Time.deltaTime  * speed; // * inputManager.forward;
    }
    public void SetPhysics(bool isKinematic)
    {
        GetComponent<Rigidbody>().isKinematic = !isKinematic;
    }
    void SetPhysics(bool isKinematic, float delay)
    {
        StartCoroutine(SetPhysicsCoroutine(delay, isKinematic));
    }
    IEnumerator SetPhysicsCoroutine(float delay, bool isKinematic)
    {
        yield return new WaitForSeconds(delay);
        SetPhysics(isKinematic);
        yield return null;
    }
}
