using UnityEngine;
using System.Collections;

public class CharacterModel : MonoBehaviour {

    public Animation anim;

	void Start () {
        anim.GetComponent<Animation>();
	}
    public void Idle()
    {
        anim.Play("Idle01");
    }
    public void Walk()
    {
        anim.Play("Move01_F");
    }
}
