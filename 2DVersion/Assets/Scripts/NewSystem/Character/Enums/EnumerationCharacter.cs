using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public abstract class EnumerationCharacter : IComparable
{
    private int _valueID;
    private string _displayName;
    private CharacterStats _characterStats;
    private CharacterHealth _characterHealth;
    private CharacterAttacks _characterAttacks;
    private CharacterSpells _characterSpells;
    private CharacterPassives _characterPassives;
    private CharacterReactions _characterReactions;
    private CharacterMovement _characterMovement;

    protected EnumerationCharacter()
    {

    }

    protected EnumerationCharacter(int value, string displayName)
    {
        _valueID = value;
        _displayName = displayName;

    }

    protected EnumerationCharacter( int value, string displayName,CharacterStats characterStats, CharacterHealth characterHealth, CharacterAttacks characterAttacks, CharacterSpells characterSpells, CharacterPassives characterPassives, CharacterReactions characterReactions, CharacterMovement characterMovement) 
    {
        _valueID = value;
        _displayName = displayName;
        _characterStats = characterStats;
        _characterHealth = characterHealth;
        _characterAttacks = characterAttacks;
        _characterSpells = characterSpells;
        _characterPassives = characterPassives;
        _characterReactions = characterReactions;
        _characterMovement = characterMovement;

    }
    public CharacterStats Stats
    {
        get { return _characterStats; }
        set { _characterStats = value; }
    }
    public CharacterHealth Health
    {
        get { return _characterHealth; }
        set { _characterHealth = value; }
    }
    public CharacterAttacks Attacks
    {
        get { return _characterAttacks; }
        set { _characterAttacks = value; }
    }
    public CharacterSpells Spells
    {
        get { return _characterSpells; }
        set { _characterSpells = value; }
    }
    public CharacterPassives Passives
    {
        get { return _characterPassives; }
        set { _characterPassives = value; }
    }
    public CharacterReactions Reactions
    {
        get { return _characterReactions; }
        set { _characterReactions = value; }
    }
    public CharacterMovement Movement
    {
        get { return _characterMovement; }
        set { _characterMovement = value; }
    }
    public int Value
    {
        get { return _valueID; }
        set { _valueID = value; }
    }
    public string DisplayName
    {
        get { return _displayName; }
        set { _displayName = value; }
    }



    public override string ToString()
    {
        return DisplayName;
    }


    public static IEnumerable<T> GetAll<T>() where T : EnumerationCharacter, new()
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
        var otherValue = obj as EnumerationCharacter;

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

    public static int AbsoluteDifference(EnumerationCharacter firstValue, EnumerationCharacter secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
        return absoluteDifference;
    }

    public static T FromValue<T>(int value) where T : EnumerationCharacter, new()
    {
        var matchingItem = parse<T, int>(value, "value", item => item.Value == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : EnumerationCharacter, new()
    {
        var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
        return matchingItem;
    }

    private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : EnumerationCharacter, new()
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
        return Value.CompareTo(((EnumerationCharacter)other).Value);
    }
}