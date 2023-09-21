using UnityEngine;
[CreateAssetMenu(menuName = "effect/buffDmg")]

public class buffDmg : Effect
{
    public int buffScale = 3;//don vi %
    public override void startEffect(GameObject targets,GameObject source=null)
    {
        base.startEffect(targets);
        var player = targets.GetComponent<playerInfo>();
        player.onChain.AddListener(
            buff
        );
    }
    public override void endEffect(GameObject targets,GameObject source=null)
    {
        base.endEffect(targets);
        targets.GetComponent<playerInfo>().onChain.RemoveListener(
            buff
        );
    }
    public override void triggerEffect(GameObject targets,GameObject source=null)
    {
        base.triggerEffect(targets);

    }
    public void buff(playerInfo player, Effect effect)
    {
        if (effect.GetType() == typeof(damage))
        {
            damage dmg = effect as damage;
            dmg.dmg *= buffScale;
        }
        effect.trigger(player.gameObject);
        player.chainEffect.Add(effect);
    }
    //change
}