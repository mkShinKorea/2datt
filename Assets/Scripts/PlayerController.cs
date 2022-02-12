using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {
    bool _isDead = false;
    bool isJump = false;
    bool isPlayed = false;

    public AudioClip jump;
    public AudioClip land;
    public AudioClip die;


    public bool IsDead {
        set {
            _isDead = value;
        }
        get {
            return _isDead;
        }
    }

    Animator ani;
    Rigidbody2D rig;
    AudioSource au;

    private void Start() {
        ani = gameObject.GetComponent<Animator>();
        au = gameObject.GetComponent<AudioSource>();
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (IsDead) {
            if (!isPlayed)
            {
                au.PlayOneShot(die);
                isPlayed = true;
            }
            
            
            rig.bodyType = RigidbodyType2D.Kinematic;
            rig.simulated = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("스페이스바가 눌렸습니다!");

            if (transform.position.y <= -1.17) {
                rig.AddForce(new Vector3(0, 500f, 0));
                ani.SetBool("Jump", true);
                au.PlayOneShot(land);
            }
        }
    }

    private void Update() {
        if (IsDead) {
            ani.SetBool("Dead", true);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Contains("Ground")) {
            ani.SetBool("Jump", false);
            if (isJump)
            {
                au.clip = land;
                au.Play();
            }
            isJump = false;

            
        }
    }

    public void initGame() {
        IsDead = false;
        isPlayed = false;


        ani.SetBool("Dead", false);

        rig.bodyType = RigidbodyType2D.Dynamic;
        rig.simulated = true;
    }

    public void OnPlayerDead() {
        IsDead = true;
    }
}
