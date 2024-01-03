using TMPro;
using Unity.Netcode;
using UnityEngine;

public class damage : Effect
{
    public int dmg = 0;
    public DmgType dmgType;

    public void Dmg(int damage, DmgType dmgType, GameObject targets)
    {
        var player = targets.GetComponent<playerInfo>();
        player.takeDamage(dmg, dmgType);
    }

    public override void NetworkSerialize<T>(BufferSerializer<T> serializer)
    {
        base.NetworkSerialize(serializer);
        serializer.SerializeValue(ref dmg);
        serializer.SerializeValue(ref dmgType);
    }
}

