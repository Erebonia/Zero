using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int loadIndex)
    {
        //Play fade animation.
        anim.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load New
        SceneManager.LoadScene(loadIndex, LoadSceneMode.Additive);
    }
}
