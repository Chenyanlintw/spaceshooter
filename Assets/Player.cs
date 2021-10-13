using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;  // 子彈（用來複製）
    public GameObject firePoint;  // 發射點 (Empty)

    Rigidbody rb;
   
    void Start()
    {
        // 取得剛體元件
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        // 如果按下空白鍵
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 複製子彈到發射點上
            Instantiate(bullet, firePoint.transform.position, Quaternion.Euler(0,0,0));
        }    
    }


    void FixedUpdate()
    {
        // 取得左右方向操作
        float h = Input.GetAxis("Horizontal");

        // 左右移動剛體
        rb.velocity = new Vector3(h * 5f, 0, 0);

        // 傾斜
        rb.rotation = Quaternion.Euler(-90f + h * 30f, 90f, -90f);
    }
}
