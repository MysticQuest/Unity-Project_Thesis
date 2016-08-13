using UnityEngine;
using System.Collections;

public class WarpAuto : MonoBehaviour
{
    public Transform target;
    void OnTriggerStay2D(Collider2D warpToHome)
    {
            warpToHome.transform.position = target.position;
    }
}
