using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Gamemanger : MonoBehaviour
{
    
    

    public bool stopFlag = false; 
    public bool turnFlag = false;
    void Start()
    {
        
    }
    
    

    

    public void Find() // 스캔
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
