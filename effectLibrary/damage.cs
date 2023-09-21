using TMPro;
using UnityEngine;

public class damage : Effect
{
    public int dmg = 0;
    public DmgType dmgType;

    public void Dmg(int damage, DmgType dmgType, GameObject targets)
    {
        var player = targets.GetComponent<playerInfo>();
        player.takeDamage(dmg, dmgType);

        breakArmor breakEffect = new breakArmor();

        player.addChain(breakEffect);

    }
    public void showDmg(int dmg,DmgType dmgType){
        var go=Instantiate(playerAssetEffect.Instance.dmgShowObj);
        var text=go.GetComponentInChildren<TMP_Text>();
        text.text=System.String.Format("<color={0}>{1}</color>",Dic.singleton.colorOfDame[dmgType],dmg);
    }
}

