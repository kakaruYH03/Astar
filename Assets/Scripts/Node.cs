using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float FScore
    {
        get
        {
            return hScore + gScore;
        }
    }

    public float fScore;        // H+G 합한 값
    public float hScore;        // Node에서 목적지까지 직선 거리를 점수로 표현한 것
    public float gScore;        // 출발지에서 현재 Cell까지 거리를 점수로 표현한 것
    public Node parent;         // 자신을 찾아준 부모 Cell

    public Vector3 position;    // 위치값
    public bool isObstacle;     // 장애물인지 아닌지 여부

    public Node(Vector3 position)
    {
        this.hScore = 0f;
        this.gScore = 0f;
        this.isObstacle = false;
        this.parent = null;
        this.position = position;
    }
}