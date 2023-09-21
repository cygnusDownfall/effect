using UnityEngine;
[CreateAssetMenu(menuName ="effect/lockSkill")]
public class lockSkill:Effect{
    public override void startEffect(GameObject targets,GameObject source=null)
    {
        base.startEffect(targets);

    }
    public override void endEffect(GameObject targets,GameObject source=null)
    {
        base.endEffect(targets);
    }
}