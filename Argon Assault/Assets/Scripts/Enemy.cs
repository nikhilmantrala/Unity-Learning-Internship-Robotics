using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] GameObject DeathVFX;
    [SerializeField] GameObject HitVFX;
    GameObject parentGameObject;
    [SerializeField] int scoreIncrease = 15;
    [SerializeField] int hitpoints = 2;

    ScoreBoard scoreBoard;


    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnRuntime");
        AddRigidbody();

    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitpoints <= 0)
            KillEnemy();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject hitvfx = Instantiate(HitVFX,transform.position, Quaternion.identity);
        hitvfx.transform.parent = parentGameObject.transform;
        hitpoints--;
        scoreBoard.IncreaseScore(scoreIncrease);
    }
}
