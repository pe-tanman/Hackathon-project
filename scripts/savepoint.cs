using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepoint : MonoBehaviour
{
    [SerializeField]
    int this_point;
    public static int player_point;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        player_point = this_point;
    }
}
