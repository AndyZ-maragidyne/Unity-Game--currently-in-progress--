using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public int healAmount = 1;

    public override void OnPickup(PlayerScript player)
    {
        player.increaseLives(healAmount);
    }
}
