using UnityEngine;
using System.Collections;

public class CharacterTransportInUniverse : MonoBehaviour {

    public float distance = 50;
    public UI_Universe ui_universe;
    public states state;
    public int rot_x = 0;
    public int rot_y = 0;
    public Transform target;

    public enum states
    {
        NONE,
        TOWARDS,
        ROTATING
    }

    public void RotateInTransport(int id)
    {
        if (state == states.ROTATING) return;
        state = states.ROTATING;
        switch (id)
        {
            case 1:
                rot_y += 90;
                break;
            case 2:
                rot_y -= 90;
                break;
            case 3:
                rot_x += 90;
                break;
            case 4:
                rot_x -= 90;
                break;
        }
        if (rot_y == 360) rot_y =0;
        if (rot_y < 0) rot_y = 360 + rot_y;
        if (rot_y >360) rot_y = 360 - rot_y;

        if (rot_x == 360) rot_x = 0;
        if (rot_x < 0) rot_x = 360 + rot_x;
        if (rot_x > 360) rot_x = 360 - rot_x;

        Rotating();
    }
    void Rotating()
    {
        iTween.RotateTo(gameObject, iTween.Hash(
            "x", rot_x,
            "y", rot_y,
            "time", 1f,
            "oncomplete", "ready",
            "easetype", iTween.EaseType.easeOutQuad
            )
        );
    }
    public void MoveTowards()
    {
        if (state == states.TOWARDS) return;
        state = states.TOWARDS;
      
        Vector3 pos = target.position;
        print(pos);

        iTween.MoveTo(gameObject, iTween.Hash(
         "position", pos,
         "time", 1f,
         "oncomplete", "ready",
         "easetype", iTween.EaseType.easeOutQuad
         )
     );
    }
    void ready()
    {
        print("done");
        Idle();
    }
    void Idle()
    {
        state = states.NONE;
    }
}
