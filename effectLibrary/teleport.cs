using UnityEngine;
public class teleport:Effect{
    public override string effect_detail { get => base.effect_detail; set => base.effect_detail = value; }
    public override void endEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets, source);
        var dir=(targets.transform.position-source.transform.position).normalized;
        source.transform.position=targets.transform.position-0.1f*dir;
    }
}