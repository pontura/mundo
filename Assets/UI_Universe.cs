using UnityEngine;
using System.Collections;

public class UI_Universe : MonoBehaviour
{
    public CharacterTransportInUniverse characterInUniverse;

    public void OnDown(int id)
    {
        switch (id)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                characterInUniverse.RotateInTransport(id);
                break;
            case 5:
                characterInUniverse.MoveTowards();
                break;
        }
    }
}
