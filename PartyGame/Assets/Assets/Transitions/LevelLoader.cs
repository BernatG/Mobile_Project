using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool active = false;
   
    public void OnMovieEnded(int nextNumberScene)
    {
        StartCoroutine(LoadLevel(nextNumberScene));        
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
