using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    public int lives;

    public int bricks;

    public float resetDelay;

    public Text livesText;

    public GameObject gameOver;

    public GameObject victory;

    public GameObject bricksPrefab;

    public GameObject paddle;

    public static GMScript instance = null;

    private GameObject clonePaddle;

    public int currentlevel;

    public bool stop;

    public Text pointsText;

    public int points;

	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SetUp();
	}
	
    public void SetUp()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }


    public void CheckGameOver()
    {
        if (currentlevel == 1)
        {
            if (bricks < 1)
            {
                SceneManager.LoadScene("Level2");
            }

            if (lives < 1)
            {
                gameOver.SetActive(true);
                stop = true;
            }
        }
        else
        {
            if (bricks < 1)
            {
                victory.SetActive(true);
                stop = true;
            }

            if (lives < 1 )
            {
                if (victory == false)
                {
                    gameOver.SetActive(true);
                }
                stop = true;
            }
        }
    }

	public void LoseLives ()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Destroy(clonePaddle);
        Invoke ("SetupPaddle", resetDelay);
        CheckGameOver();
	}

    public void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick(int brickPoints)
    {
        bricks--;

        points = points + brickPoints;

        pointsText.text = "Points: " + points;

        CheckGameOver();
    }
}
