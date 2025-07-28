using UnityEngine;

public class GroundBlockScript : MonoBehaviour
{
    public Transform otherBlock;
    public float halfLength = 100f;
    private Transform player;
    private float endOffset = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }

    void MoveGround()
    {
        if(transform.position.z + halfLength < player.transform.position.z - endOffset)
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, otherBlock.position.z + halfLength * 2);
        }
    }
}
