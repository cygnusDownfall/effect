using UnityEngine;
[CreateAssetMenu(menuName = "effect/healing/continuesHealing")]
public class continuesHealing : healing
{
    public override string effect_detail
    {
        get => System.String.Format(
        (heal == 0) ? "" :
            (
            ((effect_rate != 100) ? "Có tỷ lệ {0}%" : "") +
            "mỗi giây hồi {1} máu"
            )
        , effect_rate, heal
        );
        set => base.effect_detail = value;
    }
    public override void triggerEffect(GameObject targets, GameObject source = null)
    {
        base.triggerEffect(targets);
        targets.GetComponent<playerInfo>().healing(heal);
    }
}
//