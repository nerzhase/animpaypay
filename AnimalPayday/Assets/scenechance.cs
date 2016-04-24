using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenechance : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            //Application.LoadLevel("phase2");
            SceneManager.LoadScene("phase2");

        }


    }
}