using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Gamemanger : MonoBehaviour
{
    //private List<Unit> turnOrder = new List<Unit>(); // 유닛들 들어갈 리스트
    

    public bool stopFlag = false; // 전투 종료 플래그
    public bool turnFlag = false;
    void Start()
    {
        
    }
    
    

    

    public void Find() // 적들 스캔, 없으면 전투 종료
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        if (enemies.Length == 0)
        {
            Debug.Log("검출되지 않음");
            End();
        }
        

    }
    
    public void End()// 전투 종료
    {
        stopFlag = true;
    }
}
