using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    private PlayerController playercontroller;
    private Animator anim;
    
    void Start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    void ResetShooting()
    {
        playercontroller.canShoot = true;
        anim.Play("Idle");
    }

    //void CamerStartGame()
    //{
    //    SceneManager.LoadScene("Gameplay");
    //}
}
