using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D Rigid;
    public Vector2 JumpForce;
    public bool Grounded = true;

    public Text TimerText;
    public GameObject GameOverText;

    private float _score = 0;
    bool _gameEnded;

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

        if (_gameEnded == false)
        {
            _score += Time.deltaTime;
            TimerText.text = _score.ToString("0") + " Yards";
        }

	}

    private void GameOver()
    {
        GameOverText.SetActive(true);
        Debug.Log("Game Over");

        _gameEnded = true;

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
