using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class YilanGez : MonoBehaviour
{
    Vector2 dir = Vector2.left;
    Vector2 a;
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject kuyruk;
    
    void Start()
    {
        
        InvokeRepeating("Move", 0.1f, 0.1f);
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        a = dir / 5f;
    }

    void Move()
    {
        Vector2 v = transform.position;

        
        transform.Translate(a);

        if (ate)
        {
           
            GameObject g = (GameObject)Instantiate(kuyruk,
                                                  v,
                                                  Quaternion.identity);
            
            tail.Insert(0, g.transform);

            
            ate = false;
        }
        
        else if (tail.Count > 0)
        {
            
            tail.Last().position = v;
            
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
       
        if (coll.name.StartsWith("yemek"))
        {
            
            ate = true;

           
            
            Destroy(coll.gameObject);
        }
       
        else
        {

            void OnGUI()
            {
                if (GUILayout.Button("Restart"))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }

        }

    }
}