﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class GemCtr : NghiaMono
{
    protected static GemCtr instance;
    public static GemCtr Instance => instance;
    [SerializeField] protected BoxCollider2D _collider;
    [SerializeField] protected GemDespawn gemDespawn;
    public GemDespawn GemDespawn => gemDespawn;
    [SerializeField] protected GemMove gemMove;
    public GemMove GemMove => gemMove;


    public GemType GemType;
    public int xIndex;
    public int yIndex;
    public bool ItMatched;
    protected Vector2 currentpos;
    protected Vector2 targetpos;
    
    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadTrigger();
        this.LoadGemDespawn();
        this.LoadGemMove();
    }
    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<BoxCollider2D>();
        this._collider.isTrigger = false;
        this._collider.size = new Vector2(0.8f, 0.8f);
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }
    protected virtual void LoadGemDespawn()
    {
        if (this.gemDespawn != null) return;
        this.gemDespawn = transform.GetComponentInChildren<GemDespawn>();
        Debug.Log(transform.name + " :LoadGemDespawn", gameObject);
    }
    protected virtual void LoadGemMove()
    {
        if (this.gemMove != null) return;
        this.gemMove = GetComponentInChildren<GemMove>();
        Debug.Log(transform.name + " :LoadGemMove", gameObject);
    }

   public void SetIndicies(int _x, int _y)
    {
        xIndex = _x;
        yIndex = _y;
    }

}

public enum GemType
{
    Blue,
    Red,
    Green,
    Gold,
    Purple,
    Lilac,
    Bomb
} 