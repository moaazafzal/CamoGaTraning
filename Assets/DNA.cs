using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public static DNA instance;
    public float r,g,b,s;
    bool dead = false;
    public float timeToDie = 0;
    SpriteRenderer sRendere;
    Collider2D sCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
           sRendere = GetComponent<SpriteRenderer>();
        sCollider = GetComponent<Collider2D>();

        sRendere.color = new Color(r, g, b);
        this.transform.localScale = new Vector3(s, s, s);
    }
    public void playerColor()
    {
       
    }
    private void OnMouseDown()
    {
        dead = true;
        timeToDie = PopulationManager.elapsed;
        sRendere.enabled = false;
        sCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
