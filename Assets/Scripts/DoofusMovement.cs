using UnityEngine;

public class DoofusMovement : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody rb;

    void Start()
    {
        moveSpeed = ConfigManager.doofusDiary.player_data.speed;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        rb.MovePosition(transform.position + movement);
    }
}
