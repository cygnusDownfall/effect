using UnityEngine;
[CreateAssetMenu(menuName ="effect/stun")]
public class stun:Effect
{
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets, source);
        targets.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
        
    }
    public override void endEffect(GameObject targets, GameObject source = null)
    {
        base.endEffect(targets, source);
        targets.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.None;
    }
}
