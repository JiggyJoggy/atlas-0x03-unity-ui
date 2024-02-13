using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;

    public int health;
    public Text healthText;

    private int score = 0;
    public Text scoreText;

    public Text winLoseText;
    public Image winLoseBG;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigid.AddForce(Vector3.right * speed);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigid.AddForce(-Vector3.right * speed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rigid.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigid.AddForce(-Vector3.forward * speed);
        }

        if (health == 0)
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;

            StartCoroutine(LoadScene(3));

            health = 5;
            score = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            winLoseBG.gameObject.SetActive(true);
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;

            winLoseBG.color = Color.green;

            StartCoroutine(LoadScene(3));

        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
