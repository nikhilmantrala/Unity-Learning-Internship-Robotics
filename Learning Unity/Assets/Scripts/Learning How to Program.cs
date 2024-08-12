using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LearningHowtoProgram : MonoBehaviour
{
    private Rigidbody2D myBody;
    private BoxCollider2D myCollidor;
    private AudioSource audioSource;
    private Animator anim;
    private Transform myTranform;
    Player warrior;
    Player archer;

    //first function called
    private void Awake(){}
    //2nd functionc called
    private void OnEnable(){}

    //third function called
    private void Start()
    {   

        myBody = GetComponent<Rigidbody2D>();
        myTranform = transform;
        myTranform.position = new Vector3(10, 20, 30);
            
            
            
            
            
            
            
            
            
            
            //StartCoroutine(ExecuteSomething());

        //     Player player = new Player(1, 1, "Player");
        //     player.Info();
        //     player.Attack();

        //     Warrior warrior = new Warrior(3, 5, "Warrior");
        //     warrior.Info();
        //     warrior.Attack();

        //     Archer archer = new Archer(5, 3, "Archer");
        //     archer.Info();
        //     archer.Attack();
        
        }

    // IEnumerator ExecuteSomething(){

    //     yield return new WaitForSeconds(2f);
    // }

    }

// or is ||
// and is &&

