using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusManager : MonoBehaviour {
    public GameObject[] cactus = new GameObject[3];

    public float interval = 1.5f; // 선인장을 스폰하는 간격

    private float nowInterval = 0f;

    // 0~2 : 선인장 A, B, C
    // 3 : 빈 공간 (스폰 X)

    private void Update() {
        if (nowInterval >= interval) {
            nowInterval = 0;
            int random = Random.Range(0, 4);

            if (random != 3) {
                GameObject obj = Instantiate(cactus[random], new Vector3(10f, -1.19f, 0), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
            }
        }

        nowInterval += Time.deltaTime;
    }

    public void initGame()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject t in obs)
        {
            Destroy(t);
        }
       
     
    }
}
