using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoMaze : MonoBehaviour
{
    public GameObject[] mazeWall;
    public ArrayList inventory = new ArrayList();
    public int mazeSize = 10;

    private void Start()
    {
        for (int i = 0; i < mazeSize; i++)
        {
            for (int j = 0; j < mazeSize; j++)
            {
                inventory.Add(i + j);
                Debug.Log("i value is: " + i + "/j value is: " + j);

                if (i == 0 && j == 0) //CORNER BL
                {
                    GameObject clone = Instantiate(mazeWall[9], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i == mazeSize - 1 && j == mazeSize - 1) //CORNER UR
                {
                    GameObject clone = Instantiate(mazeWall[7], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i == 0 && j == mazeSize - 1) //CORNER UL
                {
                    GameObject clone = Instantiate(mazeWall[6], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i == mazeSize - 1 && j == 0) //CORNER BR
                {
                    GameObject clone = Instantiate(mazeWall[8], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i == 0 && j != 0) //EDGE L
                {
                    GameObject clone = Instantiate(mazeWall[2], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i != 0 && j == mazeSize - 1) //EDGE U
                {
                    GameObject clone = Instantiate(mazeWall[3], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i != 0 && j == 0) //EDGE B
                {
                    GameObject clone = Instantiate(mazeWall[5], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i == mazeSize - 1 && j != 0) //EDGE R
                {
                    GameObject clone = Instantiate(mazeWall[4], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if ((i != 0 && j != 0) && (i != mazeSize - 1 && j != mazeSize - 1))
                {
                    int randomValue = Random.Range(2, 5);
                    GameObject clone = Instantiate(mazeWall[randomValue], new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}