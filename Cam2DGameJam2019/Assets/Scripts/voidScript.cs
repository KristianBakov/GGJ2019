using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voidScript : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainPlayer")

        {
            Debug.Log("You Died");
            SceneManager.LoadScene(level);
        }
    }

}
