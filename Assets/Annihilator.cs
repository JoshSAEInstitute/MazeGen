using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Annihilator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
