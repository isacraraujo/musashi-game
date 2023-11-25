
using UnityEngine;

public interface IDamageble {
    public float Health { set; get; }
    public bool Targetable { set; get; }
    public void OnHit (float damage, Vector2 knockback);
    public void OnHit(float damage);
    
    //public void MakeUntargetable();
    
}