using UnityEngine;
using System.Collections;


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
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<GroundBlockScript>().halfLength;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();

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

    IEnumerator GenerateObstacle()
    {
        float timer = Random.Range(min_ObstacleDelay, max_ObstacleDelay) / playerController.speed.z;
        yield return new WaitForSeconds(timer);

        CreateObstacle(playerController.gameObject.transform.position.z + halfGroundSize);

        StartCoroutine(GenerateObstacle());
    }

    void CreateObstacle(float zPos)
    {
        int obstacleLane = Random.Range(0, lanes.Length);
        Vector3 obstaclePos = new Vector3(lanes[obstacleLane].transform.position.x, 0.0f, zPos);
        AddObstacle(obstaclePos, Random.Range(0, obstaclePrefabs.Length));

        int r = Random.Range(0, 10);
        

        if (0 <=r && r < 7)
        {
            //int obstacleLane = Random.Range(0, lanes.Length);

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x, 0f, zPos), Random.Range(0, obstaclePrefabs.Length));

            int zombieLane = 0;
            if (obstacleLane == 0)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 1 : 2;
            }
            else if (obstacleLane == 1)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (obstacleLane == 2)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 0 : 1;
            }
            AddZombie(new Vector3(lanes[zombieLane].transform.position.x, 0.5f, zPos)); // Adjust Y as needed;
        }
    }

    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[type], position, Quaternion.identity);
        bool mirror = Random.Range(0, 2) == 1;

        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -1 : 1, 0f);
                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);
                break;
        }
        obstacle.transform.position = position;
    }

    void AddZombie(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;

        for (int i = 0; i < count; i++)
        {
            Vector3 shift =new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(1f, 10f));
            Instantiate(zombiePrefabs[Random.Range(0, zombiePrefabs.Length)], pos + shift * i, Quaternion.identity);
        }
    }
}
