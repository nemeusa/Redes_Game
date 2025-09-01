using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectYWhere : MonoBehaviour
{
    public string name;
    public int maxHP;
    public int hp;
    public Color color;
    public Vector2 position;
    public Vector2 facing;

    public List<SelectYWhere> character;

    public SelectYWhere(string name, int maxHP, Color color, Vector2 position, Vector2 facing)
    {
        this.name = name;
        this.maxHP = maxHP;
        hp = maxHP;
        this.color = color;
        this.position = position;
        this.facing = facing;
    }

    public enum Health { Damaged, OK, NearDeath };
    public enum Factor { Ally, Neutral, Enemy}
    public enum Decision { Ignore, Follow, Attack}

    void method()
    {
        var names = character.Select(x => x.name);
        var hp = character.Select(x => x.hp);
    }

    //public List<Health> PlayerConditions()
    //{
    //    var conditions = character.Select(x =>
    //    {
    //        var percentage = x.maxHP / x.hp;

    //        return percentage > 0.9f ? Health.OK : percentage > 0.1f ? Health.Damaged : Health.NearDeath;
    //    })
        

    //    return conditions;
    //}

}
