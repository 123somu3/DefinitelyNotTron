using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour

{
    Transform player;
    [SerializeField]
    float enemySpeed, dis;
    Vector3 StartPos;
    public int Scene;
    private void Start()
   
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartPos = transform.position;
    }

    private void Update()
    {
        dis = Vector3.Distance(transform.position, player.position);
        if (dis <= 8f)
        {
            chase();
        }
        if (dis > 8f)
        {
            goHome();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
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
        transform.position = Vector3.Lerp(transform.position, StartPos, 0.005f);

    }
}
