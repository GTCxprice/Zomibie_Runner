using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody mybody;

    void Awake()
    {
        mybody = GetComponent<Rigidbody>();
    }


    public void move(float speed){
    mybody.AddForce(transform.forward.normalized * speed);
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
