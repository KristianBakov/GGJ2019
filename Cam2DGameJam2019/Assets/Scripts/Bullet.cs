using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 7.0f;
    public string level;

    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("MainPlayer");
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3.0f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainPlayer")

        {
            Debug.Log("You Died");
            SceneManager.LoadScene(level);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
