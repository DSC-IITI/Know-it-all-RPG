using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyScript : MonoBehaviour
{
    public GameObject Enemy;
    public S_QuestTracker questTracker;
    public float speed = 2.0f;
    public int damage = 10;

    private Transform player;
    private PlayerHealth playerHealth;
    public void Kill(){
        Debug.Log(questTracker.questIndicator.name);
        if (questTracker.questIndicator.name == Enemy.name){
            questTracker.questLevelCount++;
            Debug.Log("Done12");
            questTracker.ChecknUpdateQuest();
            Debug.Log("Done22");
        }
        Destroy(Enemy);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
