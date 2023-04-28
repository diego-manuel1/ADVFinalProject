using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoverIA : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    Animator animatorPersonaje;
    public Transform MarcaDestino;
    public GameObject target;
    private GameObject realTarget;
    public Camera camara;
    public float velocidadNormal = 0.5f;
    public float velocidadCombate = 1.0f;
    public bool playerDetectado = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animatorPersonaje = GetComponent<Animator>();
        realTarget = Instantiate(target);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit) )
            {
                //agent.destination = MarcaDestino.position = hit.point;
                agent.destination = realTarget.transform.position = hit.point;
                MarcaDestino.GetComponent<AudioSource>().Play();
            }
        }
        if(agent.isOnOffMeshLink) { animatorPersonaje.SetTrigger("saltar"); }
        GetComponent<Animator>().SetFloat("Run", (transform.InverseTransformDirection(agent.velocity).x+transform.InverseTransformDirection(agent.velocity).z)*2);
    }
}
