using UnityEngine;
public class Trapdoor : MonoBehaviour
{
    public GameObject enemyPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}