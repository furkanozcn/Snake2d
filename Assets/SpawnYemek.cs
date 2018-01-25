using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnYemek : MonoBehaviour {
    public GameObject yemekPrefab;


    public Transform ust;
    public Transform alt;
    public Transform sol;
    public Transform sag;


    void Spawn()
    {
        // Sol ve Sağ pozisyon
        int x = (int)Random.Range(sol.position.x,
                                  sag.position.x);

        // Alt ve Üst Pozisyon
        int y = (int)Random.Range(alt.position.y,
                                  ust.position.y);

        
        Instantiate(yemekPrefab,
                    new Vector2(x, y),
                    Quaternion.identity);
    }
    
    void Start () {
        InvokeRepeating("Spawn", 3, 4);
    }
}
