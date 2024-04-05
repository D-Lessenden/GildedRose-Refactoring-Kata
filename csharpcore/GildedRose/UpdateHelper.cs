using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class UpdateHelper
    {
        public static void UpdateQuality(Item item)
        {
            if (!IsSulfuras(item))
            {
                if (IsAgedBrie(item))
                {
                    IncreaseQuality(item);
                }
                else if (IsBackstagePass(item))
                {
                    UpdateBackstagePass(item);
                }
                else if (IsConjured(item))
                {
                    DecreaseQuality(item);
                    DecreaseQuality(item);
                }
                else
                {
                    DecreaseQuality(item);
                }

                DecreaseSellIn(item);

                if (IsExpired(item))
                {
                    HandleExpiredItem(item);
                }
            }
        }

        private static bool IsAgedBrie(Item item) => item.Name == "Aged Brie";
        private static bool IsBackstagePass(Item item) => item.Name == "Backstage passes to a TAFKAL80ETC concert";
        private static bool IsSulfuras(Item item) => item.Name == "Sulfuras, Hand of Ragnaros";
        private static bool IsConjured(Item item) => item.Name == "Conjured Mana Cake";


        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }
        
        private static void UpdateBackstagePass(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            {
                item.SellIn--;
            }
        }

        private static bool IsExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private static void HandleExpiredItem(Item item)
        {
            if (!IsAgedBrie(item))
            {
                if (!IsBackstagePass(item))
                {
                    if (item.Quality > 0 && !IsSulfuras(item))
                    {
                        DecreaseQuality(item);
                    }
                }
                else
                {
                    item.Quality = 0;
                }
            }
            else
            {
                IncreaseQuality(item);
            }
        }
    }
}