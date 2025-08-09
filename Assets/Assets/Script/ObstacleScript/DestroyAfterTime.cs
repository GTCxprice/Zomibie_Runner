using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timer = 3f;
    void Start()
    {
        Invoke("DeactivateGameObject", timer);
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
