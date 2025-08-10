using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Animator cameraAnim;

    public void PlayGame()
    {
        cameraAnim.Play("CameraSlide");
        StartCoroutine(LoadGameAfterAnimation());
    }


    private IEnumerator LoadGameAfterAnimation()
    {
        AnimatorStateInfo stateInfo = cameraAnim.GetCurrentAnimatorStateInfo(0);

        yield return null;
        stateInfo = cameraAnim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        SceneManager.LoadScene("Gameplay");
    }


    public void QuitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
