using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float destroyTimer = 1f;

    private void Update()
    {
        Destroy(gameObject, destroyTimer);
    }
}
