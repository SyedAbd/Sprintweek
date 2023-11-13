using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 2.4f;
    public float xOffset = 6f;
    public float speed = 1f;

    public Transform target;

    void Start()
    {
        InitializeCameraPosition();
    }

    void Update()
    {
        UpdateCameraPosition();
    }

    private void InitializeCameraPosition()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = newPos;
    }

    private void UpdateCameraPosition()
    {
        float targetX = GetX();
        Vector3 newPos = new Vector3(targetX, target.position.y + yOffset, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private float GetX()
    {
        float retNum = transform.position.x + speed;
        if (retNum < target.position.x)
        {
            return retNum + 0.6f;
        }
        else if(retNum > target.position.x)
        {
            return retNum - 0.1f;
        }
        return transform.position.x + speed;
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        GameObject player = collision.gameObject;
    //        player.GetComponent<PlayerLife>().
    //        SceneManager.LoadScene(1);
    //    }
    //}
}
