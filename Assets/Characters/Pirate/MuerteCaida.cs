using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCaida : MonoBehaviour
{
    // Start is called before the first frame update
    public Spawner spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject)
        {
            //Destroy(other.gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);
            spawner.Spawn();
        }
    }
}
