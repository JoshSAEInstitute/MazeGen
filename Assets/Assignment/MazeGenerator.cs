using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MazeGenerator : MonoBehaviour
{

    //Size of the maze
    public int mazeSize = 15;
    //Store the prefab
    public GameObject myBox;

    //PerlinNoise
    public float perlinThreshold;


    void Start()
    {
        //perlinThreshold = Random.Range(0.1f, 0.5f);
        for(int i = 0; i < mazeSize; i++)
        {
            for(int j = 0; j < mazeSize; j++)
            {
                //Creates the prefab = to the mazeSize and displace it by values of i and j
                GameObject newWall = Instantiate(myBox, new Vector3(i, 0, j), Quaternion.identity);
                newWall.transform.parent = transform;
                /*
                //Generate noise value to the current prefab
                float perlinValue = Mathf.PerlinNoise(i / (float)mazeSize, j / (float)mazeSize);

                //Creates the prefab at current position if noise is below theresh hold
                if(perlinValue < perlinThreshold)
                {
                    //Creates the prefab = to the mazeSize and displace it by values of i and j
                    GameObject newWall = Instantiate(myBox, new Vector3(i, 0, j), Quaternion.identity);
                    newWall.transform.parent = transform;
                }
                */
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Perlin Threshold = " + perlinThreshold);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
