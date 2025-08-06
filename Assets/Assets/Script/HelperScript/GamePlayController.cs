using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;
    public Transform[] lanes;
    public float min_ObstacleDelay = 10f , max_ObstacleDelay = 40f;
    private float halfGroundSize;
    private BaseController playerController;
    void Awake()
    {
        makeinstance(); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<GroundBlock>().halfLength;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();
    }


    IEnumerator GenerateObstacle()
    {
        float timer = Random.range(min_ObstacleDelay, max_ObstacleDelay) / playerController.speed.z;
        yield return new WaitForSeconds(timer);

        StartCoroutine(GenerateObstacle());
    }

    void makeinstance()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}
