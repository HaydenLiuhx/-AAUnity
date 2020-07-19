using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pin : MonoBehaviour
{
    Rigidbody2D rg;
    public float speed = 20f;
    bool isPined = false;
    Spin sp;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        sp = GameObject.FindGameObjectWithTag("Roundness").GetComponent<Spin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPined)
        {
            rg.MovePosition(rg.position + Vector2.up * speed * Time.deltaTime);
            //AddForce会有加速度
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Roundness")
        {
            isPined = true;
            this.transform.SetParent(collision.gameObject.transform);
            AAGM.score -= 1;
        }
        if(collision.gameObject.tag == "Pin")
        {
            Camera.main.backgroundColor = Color.red;
            StartCoroutine(Restartlv());
            sp.speed = 50f;
        }
    }
    IEnumerator Restartlv()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
