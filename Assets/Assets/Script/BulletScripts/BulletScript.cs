using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void move(float speed){
        rb.AddForce(transform.forward.normalized * speed);
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag=="Obstacle")
        {
            gameObject.SetActive(false);
        }
    }
}
