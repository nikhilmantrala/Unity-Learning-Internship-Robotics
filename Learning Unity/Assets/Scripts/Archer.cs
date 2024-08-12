using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Player
{
    public Archer(int health, int power, string name){
        Health = health;
        Power = power;
        Name = name;
    }

    public override void Attack(){
        Debug.Log("Player is attacking with a bow");
    }


}

