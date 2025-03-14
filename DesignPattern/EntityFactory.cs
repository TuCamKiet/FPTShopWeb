using DO_AN_FPT_SHOP.Models;

namespace DO_AN_FPT_SHOP.Factories
{
    public static class EntityFactory
    {
        public static Category CreateCategory(string nameCate)
        {
            return new Category { NameCate = nameCate };
        }

        public static Product CreateProduct(int catID, string proName, int remainQuantity)
        {
            return new Product { CatID = catID, ProName = proName, RemainQuantity = remainQuantity };
        }

        public static ProDetail CreateProDetail(int proID, int supID, string function, int? pin, int? monitor, string camera, string chip, int? ram)
        {
            return new ProDetail
            {
                ProID = proID,
                SupID = supID,
                Function = function,
                Pin = pin,
                Monitor = monitor,
                Camera = camera,
                Chip = chip,
                Ram = ram
            };
        }

        public static ColorProDe CreateColorProDe(int colorID, int proDeID, string proImg)
        {
            return new ColorProDe
            {
                ColorID = colorID,
                ProDeID = proDeID,
                ProImg = proImg
            };
        }

        public static StoProDe CreateStoProDe(int stoID, int proDeID, decimal? price)
        {
            return new StoProDe
            {
                StoID = stoID,
                ProDeID = proDeID,
                Price = price
            };
        }
    }
}