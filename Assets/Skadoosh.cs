using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skadoosh : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody;
    public float speed;
    public GameObject[] BallSpawners;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            mousePos.z = 0;
            m_Rigidbody.AddForce((mousePos-transform.position) * speed);
            m_Rigidbody.gravityScale = 1;
        }
        
    }
    void OnCollisionEnter2D(Collision2D other){
        StartCoroutine(death());
    }
    public IEnumerator death(){
        m_Rigidbody.AddForce(-m_Rigidbody.velocity);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
        BallSpawners[0].GetComponent<Spawn>().Spawner();
    }
}
