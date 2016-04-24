using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {

    Renderer vase;
    CapsuleCollider collider;
    Rigidbody body;

    [SerializeField]
    float waittime = 3.1f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;

        vase = GetComponent<Renderer>();
        vase.enabled = true;

        collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Boden")

        {
            body.isKinematic = true;

            vase.enabled = false;
            collider.enabled = false;

            Debug.Log("Partikel");
            GetComponent<ParticleSystem>().Play();

            Coroutine1();


        }


            

    }

void Coroutine1()
{
    StartCoroutine(Pause(waittime));

}

    IEnumerator Pause(float waittime)
{

    yield return new WaitForSeconds(waittime);
    Debug.Log("Pause");
    Destroy(this.gameObject);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
