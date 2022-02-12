using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {
    public List<GameObject> scroll = new List<GameObject>();

    public GameObject obj;

    public float initY = -5.5f;
    public float destroyX = -13f;

    public float speed = 0.15f;
    public float distance = 4.308f;

    private void Update() {
        if (scroll.Count == 0) {
            GameObject temp2 = Instantiate(obj, new Vector3(distance, initY, 0),
                Quaternion.identity);
            temp2.transform.SetParent(gameObject.transform);

            scroll.Add(temp2);
        }
        else {
            // 화면 왼쪽 바깥으로 넘어갔을 때 오브젝트 하나를 삭제
            if (scroll[0].transform.position.x <= destroyX) {
                GameObject temp1 = scroll[0];

                scroll.Remove(temp1);
                Destroy(temp1);

                float new_x = distance;

                if (scroll.Count > 0) {
                    new_x = scroll[scroll.Count - 1].transform.position.x + distance;
                }

                GameObject temp2 = Instantiate(obj, new Vector3(new_x, initY, 0),
                    Quaternion.identity);
                temp2.transform.SetParent(gameObject.transform);

                scroll.Add(temp2);
            }
            else {
                PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

                if (player.IsDead == false) {
                    for (int i = 0; i < scroll.Count; i++) {
                        scroll[i].transform.Translate(-speed, 0, 0);
                    }
                }
            }
        }
    }
}
