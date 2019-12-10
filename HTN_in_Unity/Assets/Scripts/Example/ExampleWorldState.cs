using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleWorldState : IWorldState
{
    private AIBase owner;

    public ExampleWorldState(AIBase owner)
    {
        this.owner = owner;
    }

    public IWorldState Clone()
    {
        var newInstance = new ExampleWorldState(owner);
        newInstance.RawMeat = this.RawMeat;
        newInstance.GrilledMeat = this.GrilledMeat;
        newInstance.Bread = this.Bread;
        newInstance.Lettuce = this.Lettuce;
        newInstance.CutLettuce = this.CutLettuce;
        newInstance.IsHasPlate = this.IsHasPlate;
        newInstance.IsHasPan = this.IsHasPan;
        newInstance.IsHasCuttingBoard = this.IsHasCuttingBoard;
        newInstance.MoveTarget = this.MoveTarget;
        // newInstance.CarryTarget = this.CarryTarget;
        // newInstance.PutTarget = this.PutTarget;
        // newInstance.CutTarget = this.CutTarget;
        // newInstance.GrillTarget = this.GrillTarget;
        // newInstance.SearchTarget = this.SearchTarget;
        return newInstance;
    }

    public int RawMeat, GrilledMeat, Bread, Lettuce, CutLettuce;
    public bool IsHasPlate, IsHasPan, IsHasCuttingBoard;
    public object MoveTarget;//, CarryTarget, PutTarget, CutTarget, GrillTarget, SearchTarget;
}