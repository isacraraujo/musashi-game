using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageble
{
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool Targetable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float _health = 3f;
    public bool _targetable = true;

    public void OnHit(float damage, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(float damage)
    {
        throw new System.NotImplementedException();
    }
}
