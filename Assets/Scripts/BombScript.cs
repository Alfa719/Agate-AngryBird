using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            StartCoroutine(DestroyBomb(this.gameObject));
        }else if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(DestroyBomb(this.gameObject));
        }
    }
    IEnumerator DestroyBomb(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
