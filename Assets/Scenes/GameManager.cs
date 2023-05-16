using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector startingCinematic;
    public PlayableDirector endingCinematic;
    public GameObject[] cinematicElements;
    public bool juegoIniciado = false;
    public bool finalActivo = false;
    public GameObject CameraPlayer;
    public GameObject Player;
    public GameObject barcoAtracado;
    public AudioSource principalTheme;
    void Start()
    {
        juegoIniciado = false;
        finalActivo = false;
        principalTheme = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!juegoIniciado && startingCinematic.state == PlayState.Paused)
        {
            iniciarJuego();
        }
        else if(finalActivo && endingCinematic.state == PlayState.Paused)
        {
            //Cargar escena final
            SceneManager.LoadScene(1);
        }
    }

    public void iniciarJuego()
    {
        juegoIniciado=true;
        for(int i = 0; i < cinematicElements.Length; i++)
        {
            cinematicElements[i].SetActive(false);
        }
        Player.SetActive(true);
        CameraPlayer.SetActive(true);
        barcoAtracado.SetActive(true);

        principalTheme.loop = true;
        principalTheme.Play();
        
    }

    public void activarCinematicFinal()
    {
        finalActivo= true;
        endingCinematic.Play();
        principalTheme.Stop();
    }
}
