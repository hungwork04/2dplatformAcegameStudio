using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : ObjectPool
{
    public Pool bulletpool;
    public static PoolManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    protected override void Start()
    {

        pools.Add(bulletpool.GetHashCode(), bulletpool);
        base.Start();
    }

}
