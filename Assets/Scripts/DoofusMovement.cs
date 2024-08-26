
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoofusMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    public float fallLimit=-10f;// Y-position threshold for detecting if Doofus has fallen
    public Transform objectToCheck;
    public GameObject currentPulpit;
    void Start()
    {
        speed = ConfigManager.doofusDiary.player_data.speed;// Retrieves the speed value from the external JSON configuration through the ConfigManager
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        UnityEngine.Debug.Log(speed);
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement);
        if (objectToCheck.position.y < fallLimit)
        {
            LoadNextScene();  // Call the function to load the next scene
        }
    }
    void LoadNextScene()
    {
        // Loads the game over scene
        SceneManager.LoadScene("GameOver");
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pulpit")){
            if (currentPulpit!=other.gameObject){
                currentPulpit=other.gameObject;
                ScoreManager.instance.AddScore(1);//Add score by 1
            }
        }
    }
}
