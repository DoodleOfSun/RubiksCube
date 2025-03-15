using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class SolveTwoPhase : MonoBehaviour
{
    public ReadCube readCube;
    public CubeState cubeState;
    private bool doOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeState.started && doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    public void Solver()
    {
        readCube.ReadState();
        // 큐브 상태를 스트링으로 얻는다
        string moveString = cubeState.GetStateString();

        // 큐브 맞춘다
        string info = "";
        Debug.Log(moveString);
        string solution = SearchRunTime.solution(moveString, out info, buildTables: true);
        //string solution = Search.solution(moveString, out info);
        // 큐브가 맞춰진 문자열 리스트를 큐브를 회전시키는 로직으로 전환시킨다
        List<string> solutionList = StringToList(solution);
        Debug.Log(solution);
        // 자동화된 리스트
        Automate.moveList = solutionList;
        Debug.Log(info);
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] {""}, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}