using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door_green: MonoBehaviour {

    public GameObject open;
    public GameObject closed;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "green")
        {
            open.SetActive(true);
            closed.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "green")
        {
            open.SetActive(false);
            closed.SetActive(true);
        }
    }
}
