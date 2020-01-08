using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private static Queue<Node> closeQueue, openQueue;

    public static void FindPath(Node startNode, Node endNode)
    {
        // 탐색을 위한 Queue 설정
        openQueue = new Queue<Node>();
        openQueue.Enqueue(startNode);
        startNode.gScore = 0f;
        startNode.hScore = GetPostionSocre(startNode, endNode);

        // 탐색이 끝난 Node를 담을 Queue 설정
        closeQueue = new Queue<Node>();

        Node node = null;

        while (openQueue.Count != 0)
        {
            node = openQueue.Dequeue();

            // Node를 기준으로 갈수있는 주변 길 찾기
            ArrayList avilableNodes = GameController.Instance.GetAvailableNodes(node);

            Debug.Log("중심노드 Position : " + node.position);

            foreach (Node availableNode in avilableNodes)
            {
                Debug.Log("Available Node Position : " + availableNode.position);

                if (!closeQueue.Contains(availableNode))
                {
                    float score = GetPostionSocre(node, availableNode);

                    float newGScore = node.gScore + score;
                    float newHScore = GetPostionSocre(availableNode, endNode);

                    if (!closeQueue.Contains(availableNode))
                    {
                        openQueue.Equals(availableNode);
                    }
                }
            }
            closeQueue.Enqueue(node);
        }
        Debug.Log("Closed Queue: " + closeQueue);
    }

    private static float GetPostionSocre(Node currentNode, Node endNode)
    {
        Vector3 resultValue = currentNode.position - endNode.position;
        return resultValue.magnitude;
    }
}