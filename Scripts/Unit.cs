using System.Xml.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public class Unit : MonoBehaviour
{
    public string UnitName;
    public int MaxHP;
    public int HP;
    public int Speed;
    public Skill_Data[] skills;
    public bool IsAlive = true;
    public Animator animator;

    private TextMeshPro hpText;
    private Unit pendingTarget;
    private Skill_Data pendingSkill;

    
    void Awake()
    {
        hpText = GetComponentInChildren<TextMeshPro>();
        UpdateHpText();
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        UpdateHpText();
        if (HP <= 0)
        {
            HP = 0;
            IsAlive = false;
            TurnManager.Instance.RemoveUnit(this);
            Debug.Log($"{UnitName}은(는) 주금");
            Destroy(gameObject);
        }
    }

    public void UseSkill(int index, Unit target)
    {
        if (index < 0 || index >= skills.Length) return;

        pendingSkill = skills[index];
        pendingTarget = target;

        animator.SetTrigger("attack");

        Debug.Log($"{UnitName}이(가) {pendingSkill.SkillName} 사용 {pendingTarget.UnitName}에게 {pendingSkill.Damage} 피해");
    }

    public void ApplyDamage() 
    {
        if (pendingTarget != null && pendingSkill != null)
        {
            pendingTarget.TakeDamage(pendingSkill.Damage);
            Debug.Log($"{UnitName}이(가) {pendingSkill.SkillName} 적용 {pendingTarget.UnitName}에게 {pendingSkill.Damage} 피해");
        }
        // 중간에 바꾸기 안하면 망함
        pendingTarget = null;
        pendingSkill = null;
    }

    public IEnumerator Turn()
    {
        Debug.Log($"{name}의 턴 시작");

        Unit target = null;

        if (CompareTag("Player"))
        {
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length > 0)
            {
                GameObject targetObj = enemies[Random.Range(0, enemies.Length)];
                target = targetObj.GetComponent<Unit>();
            }
        }
        else if (CompareTag("Enemy"))
        {
            
            GameObject targetObj = GameObject.FindGameObjectWithTag("Player");
            target = targetObj.GetComponent<Unit>();
        }

        if (target != null)
        {
            int randomIndex = Random.Range(0, skills.Length);
            UseSkill(randomIndex, target);
        }

        // 대기 시간
        yield return new WaitForSeconds(2f);

        Debug.Log($"{name}의 턴 종료");
    }

    private void UpdateHpText()
    {
        if (hpText != null)
            hpText.text = HP + "/" + MaxHP;
    }


}
