using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public abstract class EnumerationEnemy : IComparable
{
    private int _valueID;
    private string _displayName;
    private RaceType _raceType;
    private string _guid;
    private EnemyInfoTest _enemyInfoTest;

    public List<AttackTemplate> _attackList;
    public List<AbilityTemplate> _ablityList;

    protected EnumerationEnemy()
    {
        _guid = Guid.NewGuid().ToString();

    }

    protected EnumerationEnemy(int value, string displayName, RaceType raceType, List<AttackTemplate> attackList,List<AbilityTemplate> ablityList)
    {
        _valueID = value;
        _displayName = displayName;
        _raceType = raceType;
        _guid = Guid.NewGuid().ToString();
        _attackList = attackList;
        _ablityList = ablityList;
    }

    public int Value
    {
        get { return _valueID; }
        set { _valueID = value; }
    }
    public EnemyInfoTest EnemyInfoTest
    {
        get { return _enemyInfoTest; }
        set { _enemyInfoTest = value; }
    }
    public RaceType RaceType
    {
        get { return _raceType; }
        set { _raceType = value; }
    }

    public string DisplayName
    {
        get { return _displayName; }
        set { _displayName = value; }
    }
    public string ID
    {
        get { return _guid; }

    }

    public override string ToString()
    {
        return DisplayName;
    }


    public static IEnumerable<T> GetAll<T>() where T : EnumerationEnemy, new()
    {
        var type = typeof(T);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        foreach (var info in fields)
        {
            var instance = new T();
            var locatedValue = info.GetValue(instance) as T;

            if (locatedValue != null)
            {
                yield return locatedValue;
            }
        }
    }

    public override bool Equals(object obj)
    {
        var otherValue = obj as EnumerationEnemy;

        if (otherValue == null)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = _valueID.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return _valueID.GetHashCode();
    }

    public static int AbsoluteDifference(EnumerationEnemy firstValue, EnumerationEnemy secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
        return absoluteDifference;
    }

    public static T FromValue<T>(int value) where T : EnumerationEnemy, new()
    {
        var matchingItem = parse<T, int>(value, "value", item => item.Value == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : EnumerationEnemy, new()
    {
        var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
        return matchingItem;
    }

    private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : EnumerationEnemy, new()
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchingItem == null)
        {
            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
            throw new ApplicationException(message);
        }

        return matchingItem;
    }

    public int CompareTo(object other)
    {
        return Value.CompareTo(((EnumerationEnemy)other).Value);
    }
}