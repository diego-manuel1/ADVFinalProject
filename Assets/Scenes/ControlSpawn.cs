using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    public Spawner[] spawners;
    private int currentSpawner;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawner= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawnear()
    {
        spawners[currentSpawner].Spawn();
    }

    public void cambiarSpawner(int posSpawner)
    {
        currentSpawner= posSpawner;
    }
}
