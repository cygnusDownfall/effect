using UnityEngine;

[CreateAssetMenu(menuName = "effect/reflection")]
public class reflection : Effect
{
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        targets.GetComponent<playerInfo>().onChain.AddListener(
            reflect
        );
    }
    public override void endEffect(GameObject targets, GameObject source = null)
    {
        base.endEffect(targets);
        targets.GetComponent<playerInfo>().onChain.RemoveListener(
            reflect
        );
    }
    public void reflect(playerInfo player, Effect effect)
    {
        if (source == null) {  return; }
        effect.trigger(source);
        
    }
}