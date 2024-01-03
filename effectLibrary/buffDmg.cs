using Unity.Netcode;
using UnityEngine;
[CreateAssetMenu(menuName = "effect/buffDmg")]

public class buffDmg : Effect
{
    /// <summary>
    /// buff x dmg
    /// </summary>
    public int buffScale = 3;
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        var player = targets.GetComponent<playerInfo>();
        player.onChain.AddListener(
            buff
        );
    }
    public override void endEffect(GameObject targets, GameObject source = null)
    {
        base.endEffect(targets);
        targets.GetComponent<playerInfo>().onChain.RemoveListener(
            buff
        );
    }
    public override void triggerEffect(GameObject targets, GameObject source = null)
    {
        base.triggerEffect(targets);

    }
    public void buff(characterInfo player, Effect effect)
    {
        if (effect.GetType() == typeof(damage))
        {
            damage dmg = effect as damage;
            dmg.dmg *= buffScale;
        }
        effect.trigger(player.gameObject);
        player.chainEffect.Add(effect);
    }
    public override void NetworkSerialize<T>(BufferSerializer<T> serializer)
    {
        base.NetworkSerialize(serializer);
        serializer.SerializeValue(ref buffScale);

    }
}