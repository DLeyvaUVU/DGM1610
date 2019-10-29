﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class CollectibleController : TriggerEvent {
    public Collectible reward;

    private void Awake() {
        var renderSprite = GetComponent<SpriteRenderer>();
        renderSprite.sprite = reward.icon.art;
        renderSprite.color = reward.icon.artColor;
    }
}
