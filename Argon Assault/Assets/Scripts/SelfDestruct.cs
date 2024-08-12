using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] float TimetillDestroy = 3f;
private void Start() {
    Destroy(gameObject, TimetillDestroy);
}
}
