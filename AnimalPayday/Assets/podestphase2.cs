using UnityEngine;
using System.Collections;

public class podestphase2 : MonoBehaviour
{

    Renderer vase;
    BoxCollider collider;
    Rigidbody body;

    [SerializeField]
    float waittime = 3.1f;

    [SerializeField]
    Mesh newmesh;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;

        vase = GetComponent<Renderer>();
        vase.enabled = true;

        collider = GetComponent<BoxCollider>();
        collider.enabled = true;

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")

        {
            body.isKinematic = true;

            collider.enabled = false;

            Debug.Log("Partikel");
            GetComponent<ParticleSystem>().Play();


            GetComponent<MeshFilter>().mesh = newmesh;


        }




    }


}