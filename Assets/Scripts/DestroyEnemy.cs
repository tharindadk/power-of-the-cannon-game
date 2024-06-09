// Attached to Bullet

using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject enemy;
    private bool isGameOver;

    void Update()
    {
        isGameOver = FindObjectOfType<GameManager>().isGameOver;

        // Destroy bullet when it's off the screen
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player") &&
            !isGameOver &&
            collision.gameObject.tag.Equals("Enemy"))
        {
            var line = FindObjectOfType<Line>();

            // Update player score
            var nowScore = FindObjectOfType<PlayerScore>().GetComponent<Text>().text.Split('%')[0];
            var nowScoreInt = int.Parse(nowScore);
            nowScoreInt += 10;
            FindObjectOfType<PlayerScore>().GetComponent<Text>().text = nowScoreInt.ToString() + "%";

            // Update enemy score
            var nowEnemyScore = FindObjectOfType<EnemyScore>().GetComponent<Text>().text.Split('%')[0];
            var nowEnemyScoreInt = int.Parse(nowEnemyScore);
            nowEnemyScoreInt -= 10;
            FindObjectOfType<EnemyScore>().GetComponent<Text>().text = nowEnemyScoreInt.ToString() + "%";

            // Move line                
            line.transform.position = new Vector2(line.transform.position.x - 1.574f, line.transform.position.y);
            
            // Destroy enemy and cannon bullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
