using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public Text gameOverText;
    private string winOrLoseText;
    public Button restartButton;
    public GameObject enemy;
    public PlayerScore playerScore;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            // show win or lose text
            gameOverText.text = winOrLoseText;
            restartButton.gameObject.SetActive(true);
        }

        // Instantiate enemy if the enemy count is less than 1
        var line = FindObjectOfType<Line>();
        var enemies = FindObjectsOfType<FireEnemyBullet>();
        if (!isGameOver && enemies.Length < 1)
        {
            var enemyPos = new Vector3(Random.Range(-7f, line.transform.position.x - 0.5f), Random.Range(-4f, 4f));
            Instantiate(enemy, enemyPos, Quaternion.identity);
        }
    }

    public void GameOver(bool isWon)
    {
        if (isWon)
        {
            winOrLoseText = "You Win!";
            var enemies = FindObjectsOfType<FireEnemyBullet>();
            foreach (var enemy in enemies)
            {
                enemy.gameObject.SetActive(false);
            }
        }
        else
        {
            winOrLoseText = "You Lose!";
        }
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
