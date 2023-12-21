using UnityEngine;

[CreateAssetMenu(menuName = "effect/healing/healing")]
public class healing : Effect
{
    public int heal;
    public override string effect_detail
    {
        get => System.String.Format(
            ((effect_rate != 100) ? "Có tỷ lệ {0}%" : "") +
            " lập tức hồi {1} máu"
            , effect_rate, heal
        );
        set => base.effect_detail = value;
    }
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        if (targets == PlayerController.Instance.player)
        {
            PlayerController.Instance.playerInfo.healing(heal);
        }
    }

}

