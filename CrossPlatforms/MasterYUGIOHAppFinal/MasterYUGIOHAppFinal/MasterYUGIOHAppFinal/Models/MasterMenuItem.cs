using System;
using System.Collections.Generic;
using System.Text;

namespace MasterYUGIOHAppFinal.Models
{
    public enum MenuItemType
    {
        monster_cards,
        ritual_monster_cards,
        link_monster_cards,
        synchro_monster_cards,
        xyz_monster_cards,
        pendulum_monster_cards,
        spell_cards,
        trap_cards
    }
    public class MasterMenuItem
    {
        public MenuItemType Type { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
