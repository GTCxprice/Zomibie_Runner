using UnityEngine;

public class ExplosideObstacle : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage = 20;

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            target.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }

        if (target.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
