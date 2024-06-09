using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
    private bool isGameOver;
    public GameObject enemy;

    private void Start()
    {

    }

    void Update()
    {
        isGameOver = FindObjectOfType<GameManager>().isGameOver;

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("EnemyBullet") &&
            !collision.gameObject.tag.Equals("Enemy") &&
            !isGameOver &&
            collision.gameObject.tag.Equals("Player"))
        {
            // Play audio
            AudioManager.Instance.PlaySFX("DestroyCannon");

            // Update player score
            var nowPlayerScore = FindObjectOfType<PlayerScore>().GetComponent<Text>().text.Split('%')[0];
            var nowPlayerScoreInt = int.Parse(nowPlayerScore);
            nowPlayerScoreInt -= 10;
            FindObjectOfType<PlayerScore>().GetComponent<Text>().text = nowPlayerScoreInt.ToString() + "%";
            if (nowPlayerScoreInt <= 0)
            {
                Destroy(collision.gameObject);
            }

            // Update enemy score
            var nowEnemyScore = FindObjectOfType<EnemyScore>().GetComponent<Text>().text.Split('%')[0];
            var nowEnemyScoreInt = int.Parse(nowEnemyScore);
            nowEnemyScoreInt += 10;
            FindObjectOfType<EnemyScore>().GetComponent<Text>().text = nowEnemyScoreInt.ToString() + "%";

            // Move line
            var line = FindObjectOfType<Line>();
            line.transform.position = new Vector2(line.transform.position.x + 1.574f, line.transform.position.y);

            // Instantiate enemy
            var enemyPos = new Vector3(Random.Range(-7f, line.transform.position.x - 0.5f), Random.Range(-4f, 4f));
            Instantiate(enemy, enemyPos, Quaternion.identity);

            // Destroy enemy bullet
            Destroy(gameObject);
        }
    }
}
