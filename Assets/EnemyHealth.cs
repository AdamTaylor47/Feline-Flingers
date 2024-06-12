using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 100f;

    private void FixedUpdate() {
        Debug.Log(health);
        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "cat"){
            takeDamage(50);
        }
        else if(collision.gameObject.tag == "boundary")
        {
            takeDamage(0);
        }
        else{
            takeDamage(10);
        }
        
    }

    void takeDamage(float damage)
    {
        health -= damage;        
    }
}
