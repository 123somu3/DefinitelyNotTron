using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour

{
    Transform player;
    [SerializeField]
    float enemySpeed, dis, maxRangeofDetection;
    Vector3 StartPos;

    public int Scene;
    private void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartPos = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            dis = Vector3.Distance(transform.position, player.position);
        }

        if (dis <= maxRangeofDetection)
        {
            chase();
        }
        if (dis > 8f)
        {
            goHome();
        }

        Debug.DrawLine(transform.position, player.position, Color.magenta);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scene);
        }
    }

    void chase()
    {
        transform.LookAt(player);
        transform.Translate(0, 0, enemySpeed * Time.deltaTime);

    }

    void goHome()
    {
        transform.LookAt(StartPos);
        transform.position = Vector3.MoveTowards(transform.position, StartPos, Time.deltaTime);

    }
}
