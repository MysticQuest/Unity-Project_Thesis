using UnityEngine;
using System.Collections;

public class ItemTriggers : MonoBehaviour
{
    public Transform target;
    void OnTriggerStay2D(Collider2D warpToHome)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            warpToHome.transform.position = target.position;
            Debug.Log("Fuck you");
        }
        else return;
    }
}