using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");   

        Vector2 moveDir = new Vector2(h, v).normalized;

        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }
}