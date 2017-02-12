using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WarpAuto : MonoBehaviour
{
    public GameObject player;
    public Transform target;

    public PlayerMovement move;

    public GameObject black;
    public Image blackimage;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        move = player.GetComponent<PlayerMovement>();

        black = GameObject.Find("Black");
        blackimage = black.GetComponent<Image>();
    }


 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            Debug.Log("ENTERED");
            //StartCoroutine(Teleport());
            //Time.timeScale = 0;
            Invoke("Teleport", 1);
            move.enabled = false;

            blackimage.CrossFadeAlpha(255f, 1f, true);
        }
    }

    public void Teleport()
    {
        Debug.Log("TELEPORT");
        //yield return new WaitForSeconds(2);
        //Time.timeScale = 1;
        player.transform.position = target.position;
        move.enabled = true;

        blackimage.CrossFadeAlpha(1f, 1f, true);

    }
}
