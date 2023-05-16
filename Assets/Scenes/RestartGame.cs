using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector finalCinematic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finalCinematic.state == PlayState.Paused)
        {
            SceneManager.LoadScene(0);
        }
    }
}
