using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance; 

    private Queue<Unit> turnQueue = new Queue<Unit>();
    private bool isProcessingTurn = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StartBattle();
    }

    
    public void StartBattle()
    {
        turnQueue.Clear();

        
        Unit[] allUnits = FindObjectsOfType<Unit>();

        
        List<Unit> aliveUnits = allUnits
            .Where(u => u.IsAlive)
            .ToList();

        
        var sorted = aliveUnits
            .OrderByDescending(u => u.Speed)
            .ThenBy(u => Random.value);

        Debug.Log("===== 전투 시작: 참여 유닛 목록 =====");
        foreach (var unit in sorted)
        {
            Debug.Log($"유닛 이름: {unit.name}, 스피드: {unit.Speed}");
            turnQueue.Enqueue(unit);
        }
        Debug.Log("================================");

        NextTurn();
    }

    
    public void NextTurn()
    {
        if (isProcessingTurn || turnQueue.Count == 0)
            return;

        StartCoroutine(ProcessTurn());
    }

    private System.Collections.IEnumerator ProcessTurn()
    {
        isProcessingTurn = true;

        if (turnQueue.Count == 0)
        {
            Debug.Log("턴을 진행할 유닛이 없음");
            yield break;
        }

        Unit current = turnQueue.Dequeue();

        if (current.IsAlive)
        {
            
            yield return StartCoroutine(current.Turn());

            
            turnQueue.Enqueue(current);
        }

        isProcessingTurn = false;

        
        NextTurn();
    }

    
    public void RemoveUnit(Unit unit)
    {
        if (turnQueue.Contains(unit))
        {
            turnQueue = new Queue<Unit>(turnQueue.Where(u => u != unit));
        }
    }
}

