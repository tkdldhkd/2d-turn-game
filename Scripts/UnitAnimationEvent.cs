using UnityEngine;

public class AnimationEventForwarder : MonoBehaviour
{
    public Unit unit; 

    public void ApplyDamage()
    {
        if (unit != null)
            unit.ApplyDamage(); 
    }
}