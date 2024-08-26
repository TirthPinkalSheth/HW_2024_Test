using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class DoofusMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;

    void Start()
    {
        speed = ConfigManager.doofusDiary.player_data.speed;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UnityEngine.Debug.Log(speed);
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement);
    }
}
