using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Text playerScore;
    private bool isGameOver = false;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            var playerScoreString = playerScore.text.Split('%')[0];
            var playerScoreInt = int.Parse(playerScoreString);
            if (playerScoreInt >= 100)
            {
                isGameOver = true;
                gameManager.GameOver(true);
            }
            if (playerScoreInt <= 0)
            {
                isGameOver = true;
                gameManager.GameOver(false);
            }
        }
    }
}
