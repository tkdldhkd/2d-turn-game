using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Gamemanger : MonoBehaviour
{
    //private List<Unit> turnOrder = new List<Unit>(); // ���ֵ� �� ����Ʈ
    

    public bool stopFlag = false; // ���� ���� �÷���
    public bool turnFlag = false;
    void Start()
    {
        
    }
    
    

    

    public void Find() // ���� ��ĵ, ������ ���� ����
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        if (enemies.Length == 0)
        {
            Debug.Log("������� ����");
            End();
        }
        

    }
    
    public void End()// ���� ����
    {
        stopFlag = true;
    }
}
