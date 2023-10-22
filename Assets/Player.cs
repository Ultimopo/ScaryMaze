using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Player : MonoBehaviour
{
    public float speed = 100;
    public Transform RespawnPoint;
    public GameObject Jumpscare;
    public string NextLevel;
    float endTime;
    bool finish;

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var MovementPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(MovementPosition);
        if (finish == true)
        {
            endTime += Time.deltaTime;
            if (endTime >= 3)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Something hit");
        if (other.gameObject.name.Contains("Wall"))
        {
            transform.position = RespawnPoint.position;
        }
        if (other.gameObject.name.Contains("EndPoint"))
        {
            SceneManager.LoadScene(NextLevel);
        }

        if (other.gameObject.name.Contains("Jumpscare"))
        {
            Jumpscare.SetActive(true);
            finish = true;
        }
        
    }
}
