using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Camera mainCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        player.GetComponentInChildren<ControlPlayer2>().mainCamera= mainCamera;
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
