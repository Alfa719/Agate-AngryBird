using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : Bird
{
    public bool isFall = false;
    
    public void Fall()
    {
        if (State == BirdState.Thrown && !isFall)
        {
            GameObject a = this.gameObject;
            a.GetComponent<Rigidbody2D>().gravityScale = 10;
            a.transform.localScale = new Vector3 (3, 3, 0);
            a.GetComponent<SpriteRenderer>().color = Color.black;
            isFall = true;
        }
    }
    public override void OnTap()
    {
        Fall();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            StartCoroutine(DestroyBomb(this.gameObject));
        }
        else if (collision.gameObject.tag == "Ground")
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
