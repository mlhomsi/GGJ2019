using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Select;

    public Animator IntroScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void StartCutscene()
    {
        IntroScene.SetTrigger("Start");
    }

    IEnumerator WaitFor ()
    {
        yield return new WaitForSeconds(1f);
    }


    public void StartGame()
    {
      //  WaitFor();
       // SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
