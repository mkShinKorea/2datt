using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {
    float speed = 0f;

    PlayerController pc;

    private void Start() {
        speed = GameObject.Find("Ground").GetComponent<Scrolling>().speed;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update() {
        if (pc.IsDead) {
            return;
        }

        if (transform.position.x <= -10.25f) {
            Destroy(gameObject);
        }

        transform.Translate(-speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            pc.OnPlayerDead();
        }
    }
}
