using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoMaze : MonoBehaviour
{
    public static int mazeSize = 10;

    public GameObject[] mazeWall;
    private int[,] inventory = new int[mazeSize, mazeSize];
    private string[,] usedCoord;


    //--- PATH
    private int startRow;
    private int startColumn;
    private int currentRow;
    private int currentColumn;
    private int endRow;
    private int endColumn;

    //--- TRAVELLING
    private int direction;
    public enum moving { idle, leftRight, rightDown, leftDown, downRight, downLeft, down}
    public moving movingState;

    private void Start()
    {

        //CREATE STARTING POINT
        startRow = Random.Range(0, mazeSize);
        startColumn = mazeSize - 1;
        //SET CURRENT POINT
        currentRow = startRow;
        currentColumn = startColumn;
        //usedCoord.Add(currentRow, currentColumn);
        //CREATE END POINT
        endRow = Random.Range(0, mazeSize - 1);
        endColumn = 0;

        /*
        for (int i = 0; i < mazeSize - 1; i++)
        {
            for (int j = 0; j < mazeSize - 1; j++)
            {

                inventory = new int[i,j];

                Debug.Log(inventory[0, 0]);


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

            }

        }
        */

        if (startRow == (mazeSize - 1))
        {
            //Edge of TOP RIGHT
            //I need a value less of it
            int a = Random.Range(0, mazeSize - 1);
            currentRow = a;
            //In case is the same value, then goes straight down
            if (a == mazeSize - 1)
            {
                int[] D = { 1, 2, 4, 14 };
                var DElement = D[Random.Range(0, D.Length)];
                GameObject clone = Instantiate(mazeWall[DElement], new Vector3(a, 0, startColumn), Quaternion.identity);
            } else
            {
                for (int b = startRow; a < b; b--)
                {
                    int[] LR = { 1, 3, 5, 15 };
                    var LRElement = LR[Random.Range(0, LR.Length)];
                    GameObject clone = Instantiate(mazeWall[LRElement], new Vector3(b, 0, startColumn), Quaternion.identity);
                }
            }
        } 
        else if (startRow == 0)
        {
            int a = Random.Range(0, mazeSize - 1);
            currentRow = a;
            //In case is the same value, then goes straight down
            if (a == 0)
            {
                int[] D = { 1, 2, 4, 14 };
                var DElement = D[Random.Range(0, D.Length)];
                GameObject clone = Instantiate(mazeWall[DElement], new Vector3(a, 0, startColumn), Quaternion.identity);
            } else
            {
                for (int b = startRow; b < a; b++)
                {
                    int[] LR = { 1, 3, 5, 15 };
                    var LRElement = LR[Random.Range(0, LR.Length)];
                    GameObject clone = Instantiate(mazeWall[LRElement], new Vector3(b, 0, startColumn), Quaternion.identity);
                }
            }
        }
        else
        {
        }
        /*
        while ((currentRow != endRow) && (currentColumn != endColumn))
        {
            if(startRow < mazeSize - 1)
            {
                //Edge of TOP RIGHT
                //I need a value less of it
                int a = Random.Range(0, mazeSize - 1);
                for(int b = startRow; a < b; b--)
                {
                    int[] LR = { 1, 3, 5, 15 };
                    var LRElement = LR[Random.Range(0, LR.Length)];
                    GameObject clone = Instantiate(mazeWall[LRElement], new Vector3(b, 0, startColumn), Quaternion.identity);
                }
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
                else if (direction == 1) movingState = moving.leftRight;
                else if (direction == 2) movingState = moving.down;

                break;

            case moving.leftRight:


                break;
            case moving.rightDown:


                break;
            case moving.leftDown:


                break;
            case moving.downRight:


                break;
            case moving.downLeft:


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

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(currentRow, 0.5f, currentColumn), new Vector3(1f, 0.5f, 1f));
    }

}