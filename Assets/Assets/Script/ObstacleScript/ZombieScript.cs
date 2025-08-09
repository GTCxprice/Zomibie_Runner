using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public GameObject bloodFXPrefab;
    public float speed = 1f;

    private Rigidbody mybody;

    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        mybody.linearVelocity = new Vector3(0, 0, -speed);
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            gameObject.SetActive(false);
        }
    }

    void die()
    {
        mybody.linearVelocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(bloodFXPrefab, transform.position, Quaternion.identity);
            Invoke("DeactivateGameObject", 3f);

            //Increase Score
            die();
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(bloodFXPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            die();
        }
    }
}
