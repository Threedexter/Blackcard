namespace Assets.Code.Base
{
    public class Loot : Target
    {
        public int PhysicalMight;
        public int MagicalMight;
        public int Food;

        /// <summary>
        /// Spawns with stats
        /// </summary>
        /// <param name="pm"></param>
        /// <param name="mm"></param>
        /// <param name="f"></param>
        public void Spawn(int pm, int mm, int f)
        {
            this.PhysicalMight = pm;
            this.MagicalMight = mm;
            this.Food = f;
        }
    }
}
