using System;
using Unity.Netcode;
using UnityEngine;
[CreateAssetMenu(menuName = "effect/unaffected")]
public class unaffected : Effect
{
    public string TargetTypeName;
    public override void NetworkSerialize<T>(BufferSerializer<T> serializer)
    {
        base.NetworkSerialize(serializer);
        serializer.SerializeValue(ref TargetTypeName);
    }
    public override string effect_detail
    {
        get
        {
            detail = String.Format("Có <color=#ffff00>{0}%</color> tỷ lệ miễn nhiễm hiệu ứng  trong {2} giây.", effect_rate, TargetTypeName, duration);
            return null;
        }
        set => base.effect_detail = value;
    }
    public Type targetType
    {
        get { return Type.GetType(TargetTypeName); }
    }
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        targets.GetComponent<playerInfo>().onChain.AddListener(
            onChain
        );
    }
    public override void endEffect(GameObject targets, GameObject source = null)
    {
        base.endEffect(targets);
        targets.GetComponent<playerInfo>().onChain.RemoveListener(
            onChain
        );
    }

    public void onChain(characterInfo player, Effect effect)
    {
        Debug.Log("effect da bi chan {0}", effect);
        if (effect.GetType() != targetType)
        {
            effect.trigger(player.gameObject);
            player.chainEffect.Add(effect);
        }
    }
}