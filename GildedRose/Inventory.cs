using System;
using System.Collections.Generic;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
        public void UpdateQuality()
        {
            // TODO ...
            // Hint: Iterate through this.items and check Name property to access specific item

            foreach (var item in this.items)
            {
                if (item.Name == "Aged Brie")
                {
                    item.SellIn--;
                    if (item.SellIn < 0)
                    {
                        if (item.Quality <= 48)
                        {
                            item.Quality = item.Quality + 2;
                        }
                    }
                    else
                    {
                        if (item.Quality <= 49)
                        {
                            item.Quality++;
                        }
                        
                    }
                }
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }
                else
                {
                    item.SellIn--;
                    if (item.Quality <= 0 || item.Quality >= 50)
                    {
                        continue;
                    }
                    else
                    {
                        
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn > 10)
                            {
                                item.Quality++;
                            } 
                            else if (item.SellIn > 5){
                                item.Quality = item.Quality + 2;
                            } 
                            else if (item.SellIn > 0)
                            {
                                item.Quality = item.Quality + 3;
                            } else
                            {
                                item.Quality = 0;
                            }
                        }
                        else if (item.Name.ToLower().Contains("conjured") && item.SellIn <= 0)
                        {
                            item.Quality = item.Quality - 4;
                        }
                        else if(item.Name.ToLower().Contains("conjured") || item.SellIn <= 0)
                        {
                            item.Quality = item.Quality - 2;
                        }
                        else
                        {
                            item.Quality--;
                        }
                    }
                }
            }
        }
    }
}
