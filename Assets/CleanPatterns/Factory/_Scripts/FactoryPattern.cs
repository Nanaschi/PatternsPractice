using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPattern : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;

    private void Start()
    {
        var npc = NPCFactory.CreateNPC(_name, _color);
        print($"{npc.Name} with a color of {npc.NpcColor}");
    }

    public class NPC
    {
        private string _name;
        private Color _npcColor;

        public string Name => _name;

        public Color NpcColor => _npcColor;

        public NPC(string name, Color npcColor)
        {
            this._name = name;
            this._npcColor = npcColor;
        }
    }

    public class NPCFactory
    {
        public static NPC CreateNPC(string name, Color npcColor)
        {
            var npc = new NPC(name, npcColor);

            return npc;
        }
    }
}