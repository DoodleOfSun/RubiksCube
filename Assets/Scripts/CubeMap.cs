using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{

    CubeState cubeState;

    public Transform Up;
    public Transform Down;
    public Transform Left;
    public Transform Right;
    public Transform Front;
    public Transform Back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set()
    {
        cubeState = FindObjectOfType<CubeState>();
        UpdateMap(cubeState.Down, Down);
        UpdateMap(cubeState.Front, Front);
        UpdateMap(cubeState.Back, Back);
        UpdateMap(cubeState.Left, Left);
        UpdateMap(cubeState.Right, Right);
        UpdateMap(cubeState.Up, Up);
    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        int i = 0;
        foreach (Transform map in side)
        {
            if (face[i].name[0] == 'F')
            {
                map.GetComponent<Image>().color = Color.yellow;
            }
            if (face[i].name[0] == 'B')
            {
                map.GetComponent<Image>().color = Color.white;
            }
            if (face[i].name[0] == 'U')
            {
                map.GetComponent<Image>().color = Color.red;
            }
            if (face[i].name[0] == 'D')
            {
                map.GetComponent<Image>().color = new Color(180, 0, 162);
            }
            if (face[i].name[0] == 'L')
            {
                map.GetComponent<Image>().color = Color.blue;
            }
            if (face[i].name[0] == 'R')
            {
                map.GetComponent<Image>().color = Color.green;
            }
            else
            {
                // empty
            }
            i++;
        }
    }
}
