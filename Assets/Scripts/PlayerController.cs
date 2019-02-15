using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D Rigid;
    public Vector2 JumpForce;
    public bool Grounded = true;

    public GameObject GameOverText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            Rigid.AddForce(JumpForce, ForceMode2D.Impulse);
            Grounded = false;
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }

	}

    private void GameOver()
    {
        GameOverText.SetActive(true);
        Debug.Log("Game Over");

        Invoke("RestartGame", 5);
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }

        if(collision.gameObject.tag == "Obstacale")
        {
            GameOver();
        }
    }

}
