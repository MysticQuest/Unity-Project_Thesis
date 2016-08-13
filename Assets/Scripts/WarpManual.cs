using UnityEngine;
using System.Collections;

public class WarpManual : MonoBehaviour
{
    public Transform target;
    void OnTriggerStay2D(Collider2D warpToHome)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            warpToHome.transform.position = target.position;
        }
        else return;
    }
}