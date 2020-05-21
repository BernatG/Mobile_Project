using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

}
