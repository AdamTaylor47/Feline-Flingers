using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHealth : MonoBehaviour
{
    float health = 100f;
    public Sprite normalWood;
    public Sprite damagedWood;
    private SpriteRenderer sr;
    private ParticleSystem ps;
    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate() {
        Debug.Log(health);
        if(health <= 50f)
        {
            sr.sprite = damagedWood;
        }
        if(health <= 0f){
            Destroy(this.gameObject);
        }
}
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "cat"){
            takeDamage(25);
        }
        else if(other.gameObject.tag == "boundary")
        {
            takeDamage(0);
        }
        else
        {
            takeDamage(5);
        }
    }

    void takeDamage(float damage){
        health -= damage;
    }
}
