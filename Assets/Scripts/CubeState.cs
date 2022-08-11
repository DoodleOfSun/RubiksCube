using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState : MonoBehaviour
{

    public List<GameObject> Front = new List<GameObject>();
    public List<GameObject> Back = new List<GameObject>();
    public List<GameObject> Up = new List<GameObject>();
    public List<GameObject> Down = new List<GameObject>();
    public List<GameObject> Left = new List<GameObject>();
    public List<GameObject> Right = new List<GameObject>();

    public static bool autoRotating = false;
    public static bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PickUp(List<GameObject> cubeSide)
    {
        foreach (GameObject face in cubeSide)
        {
            if (face != cubeSide[4])
            {
                face.transform.parent.transform.parent = cubeSide[4].transform.parent;

            }
        }
        cubeSide[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeSide);
    }

    public void PutDown(List<GameObject> littleCubes, Transform pivot)
    {
        foreach (GameObject littleCube in littleCubes)
        {
            if (littleCube != littleCubes[4])
            {
                littleCube.transform.parent.transform.parent = pivot;
            }
        }
    }

    string GetSideString(List<GameObject> side)
    {
        string sideString = "";
        foreach (GameObject face in side)
        {
            sideString += face.name[0].ToString();
        }
        return sideString;
    }

    public string GetStateString()
    {
        string stateString = "";
        stateString += GetSideString(Up);
        stateString += GetSideString(Down);
        stateString += GetSideString(Front);
        stateString += GetSideString(Back);
        stateString += GetSideString(Left);
        stateString += GetSideString(Right);
        return stateString;
    }
}
