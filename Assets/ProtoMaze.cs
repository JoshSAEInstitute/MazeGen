using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoMaze : MonoBehaviour
{
    public GameObject[] mazeWall;
    private int[,] inventory;
    private string[,] usedCoord;

    public int mazeSize = 10;

    //--- PATH
    private int startRow = 1 ;
    private int startColumn = 1;
    private int currentRow = 1;
    private int currentColumn = 1;
    private int endRow;
    private int endColumn;

    //--- TRAVELLING
    private int direction;
    public enum moving { idle, leftRight, rightDown, leftDown, downRight, downLeft, down}
    public moving movingState;

    private void Start()
    {



        //CREATE STARTING POINT
        startRow = Random.Range(0, mazeSize - 1);
        startColumn = mazeSize - 1;
        //SET CURRENT POINT
        currentRow = startRow;
        currentColumn = startColumn;
        //usedCoord.Add(currentRow, currentColumn);
        //CREATE END POINT
        endRow = Random.Range(0, mazeSize - 1);
        endColumn = 0;


        for (int i = 0; i < mazeSize; i++)
        {
            for (int j = 0; j < mazeSize; j++)
            {

                Debug.Log("Inventory " + i + ":" + j + " is " + inventory[i,j]);
                /*
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
                    int[] leftWall = { 2, 6, 9, 10, 12, 13, 14 };
                    var lElement = leftWall[Random.Range(0, leftWall.Length)];
                    GameObject clone = Instantiate(mazeWall[lElement], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i != 0 && j == mazeSize - 1) //EDGE U
                {
                    int[] upWall = { 3, 6, 7, 10, 11, 13, 15 };
                    var uElement = upWall[Random.Range(0, upWall.Length)];
                    GameObject clone = Instantiate(mazeWall[uElement], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i != 0 && j == 0) //EDGE B
                {
                    int[] bottomWall = { 5, 8, 9, 11, 12, 13, 15 };
                    var bElement = bottomWall[Random.Range(0, bottomWall.Length)];
                    GameObject clone = Instantiate(mazeWall[bElement], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (i == mazeSize - 1 && j != 0) //EDGE R
                {
                    int[] rightWall = { 4, 7, 8, 10, 11, 12, 14 };
                    var rElement = rightWall[Random.Range(0, rightWall.Length)];
                    GameObject clone = Instantiate(mazeWall[rElement], new Vector3(i, 0, j), Quaternion.identity);
                }
                else if ((i != 0 && j != 0) && (i != mazeSize - 1 && j != mazeSize - 1))
                {
                    GameObject clone = Instantiate(mazeWall[Random.Range(1, 5)], new Vector3(i, 0, j), Quaternion.identity);
                }
                */

            }

        }

        /*
        while((currentRow != endRow) && (currentColumn != endColumn))
        {
            if(startRow < mazeSize - 1)
            {
                RandomDirection();
            }
        }
        */
    }
    #region functions
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void RandomDirection()
    {
        direction = Random.Range(0, 2);

        switch(movingState)
        {
            case moving.idle:

                //---TRANSITIONS
                if (direction == 0) movingState = moving.leftRight;
                //else if (direction == 1) movingState = moving.right;
                else if (direction == 2) movingState = moving.down;

                break;

            case moving.leftRight:


                break;

            case moving.down:


                break;

            default:

                break;

        }
        Debug.Log(direction);
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(startRow, 0.5f, startColumn), new Vector3(1f, 0.5f, 1f));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(endRow, 0.5f, endColumn), new Vector3(1f, 0.5f, 1f));
    }

}