
namespace MasterYUGIOHAppFinal.Models
{
    #region All Cards Classes     


    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class AllCardsData
    {
        public Info info { get; set; }
        public List<card_data_sets> monster_cards { get; set; }
        public List<card_data_sets> ritual_monster_cards { get; set; }
        public List<card_data_sets> link_monster_cards { get; set; }
        public List<card_data_sets> synchro_monster_cards { get; set; }
        public List<card_data_sets> xyz_monster_cards { get; set; }
        public List<card_data_sets> pendulum_monster_cards { get; set; }
        public List<card_data_sets> spell_cards { get; set; }
        public List<card_data_sets> trap_cards { get; set; }
    }


    public class Info
    {
        public int last_page { get; set; }
    }

    public class Card
    {
        public int id { get; set; }
        public string title_german { get; set; }
        public string title_english { get; set; }
        public string attribute { get; set; }
        public int level { get; set; }
        public string monster_type { get; set; }
        public string card_type { get; set; }
        public string atk { get; set; }
        public string def { get; set; }
        public string card_text_german { get; set; }
        public string card_text_english { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public bool is_forbidden { get; set; }
        public bool is_limited { get; set; }
        public string imageSelected { get; set; }
        public string raritySelected { get; set; }
        public bool isCardInDeck { get; set; }
    }

    public class CardSet
    {
        public string rarity { get; set; }
        public string identifier { get; set; }
    }

    public class card_data_sets
    {
        public Card card { get; set; }
        public List<CardSet> card_sets { get; set; }
    }

    #endregion

}
