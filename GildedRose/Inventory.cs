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
                //Aged Brie
                if (item.Name == "Aged Brie")
                {
                    item.SellIn--;
                    if (item.SellIn < 0)
                    {
                            item.Quality = item.Quality + 2;
                    }
                    else
                    {
                            item.Quality++;
                    }
                }
                //Sulfuras
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
                        //Backstage passes
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn > 10)
                            {
                                item.Quality++;
                            }
                            else if (item.SellIn > 5)
                            {
                                item.Quality = item.Quality + 2;
                            }
                            else if (item.SellIn > 0)
                            {
                                item.Quality = item.Quality + 3;
                            }
                            else
                            {
                                item.Quality = 0;
                            }
                        }
                        //Conjured AND SellIn passed
                        else if (item.Name.ToLower().Contains("conjured") && item.SellIn <= 0)
                        {
                            item.Quality = item.Quality - 4;
                        }
                        //Conjured OR SellIn passed
                        else if (item.Name.ToLower().Contains("conjured") || item.SellIn <= 0)
                        {
                            item.Quality = item.Quality - 2;
                        }
                        //No special condition
                        else
                        {
                            item.Quality--;
                        }
                    }
                }
                //Quality is never higher than 50 or lower than 0 except of Sulfuras
                if (item.Quality > 50)
                {
                    item.Quality = 50;
                } else if (item.Quality < 0) {
                    item.Quality = 0;
                }
            }
        }
    }
}