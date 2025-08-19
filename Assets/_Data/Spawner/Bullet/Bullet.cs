using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObj
{
    [SerializeField] protected float speed = 10f;

    public override string GetName()
    {
        return "Bullet";
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);    
    }
  
}
