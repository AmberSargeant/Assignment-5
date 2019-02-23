using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject onigiri;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        //particles = onigiri.GetComponent<ParticleSystem>();
        ParticleSystem.EmissionModule em = particles.emission;
        em.enabled = false;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            ParticleSystem.EmissionModule em = particles.emission;
            em.enabled = true;
            particles.Play();
            
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
