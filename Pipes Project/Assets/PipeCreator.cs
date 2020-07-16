using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreator : MonoBehaviour
{
    public GameObject PipePrefab;
    public List<GameObject> PipeSectionList;
    public GameObject ValveModel;
    private GameObject Valve;

    //Debug Things
    public Material DebugMat;

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
        //Debugging Info
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
        //Debugging Info
        Debug.Log("TurnsY:");
        foreach (var i in TurnsY)
        {
            Debug.Log(i);
        }


        //Instantiate Lengths of Pipe
        //Only save non-corner, non-starting, and non-stopping pipe sections in list.
        //This list will be randomly chosen from later to figure out where the valve will be placed.
        //There will be at most 5 straight lengths of pipe from this generation method
        GameObject PipeSection;
        Vector3 PipePosition;
        //1
        int y = TurnsY[0];
        PipePosition = new Vector3(0, 0, y);
        Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        for (int i = 1; i < TurnsX[1]; i++)
        {
            PipePosition = new Vector3(i, 0, y);
            PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            PipeSectionList.Add(PipeSection);
        }
        //2
        int x = TurnsX[1];
        PipePosition = new Vector3(x, 0, TurnsY[0]);
        Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        if (TurnsY[0] < TurnsY[1])
        {
            for (int i = TurnsY[0]+1; i < TurnsY[1]; i++)
            {
                PipePosition = new Vector3(x, 0, i);
                PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
                PipeSectionList.Add(PipeSection);
            }
        }
        else
        {
            for (int i = TurnsY[0]-1; i > TurnsY[1]; i--)
            {
                PipePosition = new Vector3(x, 0, i);
                PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
                PipeSectionList.Add(PipeSection);
            }
        }
        //3
        y = TurnsY[1];
        PipePosition = new Vector3(TurnsX[1], 0, y);
        Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        for (int i = TurnsX[1]+1; i < TurnsX[2]; i++)
        {
            PipePosition = new Vector3(i, 0, y);
            PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            PipeSectionList.Add(PipeSection);
        }
        //4
        x = TurnsX[2];
        PipePosition = new Vector3(x, 0, y);
        Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        if (TurnsY[1] < TurnsY[2])
            for (int i = TurnsY[1]+1; i < TurnsY[2]; i++)
            {
                PipePosition = new Vector3(x, 0, i);
                PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
                PipeSectionList.Add(PipeSection);
            }
        else
        {
            for (int i = TurnsY[1]-1; i > TurnsY[2]; i--)
            {
                PipePosition = new Vector3(x, 0, i);
                PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
                PipeSectionList.Add(PipeSection);
            }
        }
        //5
        y = TurnsY[2];
        PipePosition = new Vector3(TurnsX[2], 0, y);
        Instantiate(PipePrefab, PipePosition, Quaternion.identity);
        for (int i = TurnsX[2]+1; i < 31; i++)
        {
            PipePosition = new Vector3(i, 0, y);
            PipeSection = Instantiate(PipePrefab, PipePosition, Quaternion.identity);
            PipeSectionList.Add(PipeSection);
        }
        PipePosition = new Vector3(31, 0, y);
        Instantiate(PipePrefab, PipePosition, Quaternion.identity);

        //Select a pipe section randomly from the list to place the valve on
        PipeSection = PipeSectionList[Random.Range(0, PipeSectionList.Count)];
        //Debug test: Highlight chosen section in a material to test that it is choosing
        PipeSection.GetComponent<Renderer>().material = DebugMat;
        //It works; Debug Commented Out
        Valve = Instantiate(ValveModel, PipeSection.transform.position, Quaternion.identity);
        //Valve.GetComponent<Transform>().SetParent(PipeSection);

        
    }
}
