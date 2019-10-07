﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float lifetime = 0.6f;
    private float tickTimer;
    // Start is called before the first frame update
    void Start()
    {
        this.tickTimer = 0.1f;
        // Choose z position.
        Vector2 pos = this.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y, -10f);
    }

    // Update is called once per frame
    public void Update()
    {
        this.lifetime -= Time.deltaTime;
        if (this.lifetime < 0f) {
            Destroy(this.gameObject);
        }
        this.tickTimer -= Time.deltaTime;
        if (this.tickTimer < 0f) {
            this.transform.rotation *= Quaternion.Euler(0f, 0f, Random.Range(90f, 270f));
            this.tickTimer = 0.1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Monster monster = collision.otherCollider.GetComponent<Monster>();
        if (monster != null) {
            monster.Enflame();
        }
    }
}
