using UnityEngine;
using System.Collections;

public class vasphase2 : MonoBehaviour
{

    Renderer vase;
    CapsuleCollider collider;
    Rigidbody body;

    [SerializeField]
    float waittime = 3.1f;

    [SerializeField]
    Mesh newmesh;

    Vector3 oldposition;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;

        vase = GetComponent<Renderer>();
        vase.enabled = true;

        collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;

        oldposition = gameObject.transform.position;

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
            Debug.Log(newmesh);


            transform.position = new Vector3(oldposition.x, 0.2f, oldposition.z);


        }




    }


}
