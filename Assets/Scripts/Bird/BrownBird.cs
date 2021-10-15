using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBird : Bird
{
    public bool _hasBomb = false;
    public GameObject bombPrefab;
    public void Bomb()
    {
        if(State == BirdState.Thrown && !_hasBomb)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(Vector2.down);
            _hasBomb = true;
        }
    }
    public override void OnTap()
    {
        Bomb();
    }
}
