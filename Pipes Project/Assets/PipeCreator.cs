using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreator : MonoBehaviour
{
    public GameObject PipePrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateRandomPipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateRandomPipe()
    {
        //Get 3 random X and Y Coordinates (and sort X)
        List<int> TurnsX = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            TurnsX.Add(Random.Range(1, 30));
        }
        TurnsX.Sort();
        Debug.Log("TurnsX:");
        foreach (var i in TurnsX)
        {
            Debug.Log(i);
        }

        List<int> TurnsY = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            TurnsY.Add(Random.Range(1, 30));
        }
        Debug.Log("TurnsY:");
        foreach (var i in TurnsY)
        {
            Debug.Log(i);
        }


        //Instantiate Lengths of Pipe
        Vector3 PipePosition;
        int y = TurnsY[1];
        for (int i = 0; i < TurnsX[1]; i++)
        {
            PipePosition = new Vector3(i, 0, y);
            Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        }
        int x = TurnsX[1];
        if (TurnsY[0] < TurnsY[1])
        {
            for (int i = TurnsY[0]; i <= TurnsY[1]; i++)
            {
                PipePosition = new Vector3(x, 0, i);
                Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            }
        }
        else
        {
            for (int i = TurnsY[0]; i >= TurnsY[1]; i--)
            {
                PipePosition = new Vector3(x, 0, i);
                Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            }
        }

        y = TurnsY[2];
        for (int i = 0; i < TurnsX[2]; i++)
        {
            PipePosition = new Vector3(i, 0, y);
            Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        }
        x = TurnsX[2];
        if (TurnsY[1] < TurnsY[2])
            for (int i = TurnsY[1]; i <= TurnsY[2]; i++)
            {
                PipePosition = new Vector3(x, 0, i);
                Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            }
        else
        {
            for (int i = TurnsY[1]; i >= TurnsY[2]; i--)
            {
                PipePosition = new Vector3(x, 0, i);
                Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            }
        }
    }
}
