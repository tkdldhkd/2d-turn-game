using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A(-1), D(+1)
        float v = Input.GetAxisRaw("Vertical");   // S(-1), W(+1)

        Vector2 moveDir = new Vector2(h, v).normalized;

        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }
}