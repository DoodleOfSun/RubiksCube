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
        // ť�� ���¸� ��Ʈ������ ��´�
        string moveString = cubeState.GetStateString();

        // ť�� �����
        string info = "";
        Debug.Log(moveString);
        string solution = SearchRunTime.solution(moveString, out info, buildTables: true);
        //string solution = Search.solution(moveString, out info);
        // ť�갡 ������ ���ڿ� ����Ʈ�� ť�긦 ȸ����Ű�� �������� ��ȯ��Ų��
        List<string> solutionList = StringToList(solution);
        Debug.Log(solution);
        // �ڵ�ȭ�� ����Ʈ
        Automate.moveList = solutionList;
        Debug.Log(info);
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] {""}, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}