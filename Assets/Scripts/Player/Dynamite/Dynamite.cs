using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] Rigidbody RB;

    [SerializeField] private float thowDistance;

    [SerializeField] private ParticleSystem smoke;

    [SerializeField] private ParticleSystem Glow;

    [SerializeField] private ParticleSystem Trails;

    [SerializeField] private Renderer bodymesh;

    [SerializeField] private float explosionForce;

    [SerializeField] private float explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.parent != null)
        {
            if (!Gamemanager.instance.CanPlayerMove)
            {
                return;
            }
            transform.parent = null;
            RB.isKinematic = false;
            RB.AddForce(transform.forward * thowDistance);
            RB.AddTorque(transform.forward * thowDistance);
            SpawnDynamite.SD.ReloadDynamite();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (transform.parent != null)
        {
            return;
        }
        Destroy(this.gameObject,1f);

      


        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if(hit.gameObject.GetComponent<IExplodable>() != null)
            {
                hit.gameObject.GetComponent<IExplodable>().Explode();
            }
        }
        colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
        


            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 3.0F);
        }

        bodymesh.enabled = false;
        RB.isKinematic = true;
        smoke.Play();
        Glow.Play(); 
        Trails.Play();
    }
}
