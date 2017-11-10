using Assets.Code.Base;
using UnityEngine;

public class Enemy : Target
{
    [SerializeField]
    private int magicalMight;
    [SerializeField]
    private int physicalMight;
    [SerializeField]
    private Loot loot;

    /// <summary>
    /// Spawns with stats
    /// </summary>
    /// <param name="mm">Magical Might</param>
    /// <param name="pm">Physical Might</param>
    /// <param name="loot">Loot</param>
    public void Spawn(int mm, int pm, Loot loot)
    {
        this.magicalMight = mm;
        this.physicalMight = pm;
        Loot x = this.gameObject.AddComponent<Loot>();
        x.Food = loot.Food;
        x.MagicalMight = loot.MagicalMight;
        x.PhysicalMight = loot.PhysicalMight;
        this.loot = x;
    }

    /// <summary>
    /// Gets the win ratio of physical
    /// </summary>
    /// <param name="physical"></param>
    /// <returns></returns>
    public WinRatio MatchPhysical(int physical)
    {
        return CalculateRatio(physical, physicalMight);
    }

    /// <summary>
    /// Gets the win ratio of physical
    /// </summary>
    /// <param name="magical"></param>
    /// <returns></returns>
    public WinRatio MatchMagical(int magical)
    {
        return CalculateRatio(magical, magicalMight);
    }

    /// <summary>
    /// Returns a ratio
    /// </summary>
    /// <param name="o"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    private WinRatio CalculateRatio(int o, int t)
    {
        // < 0.8 = easy
        if (t / o < 0.8f) return WinRatio.Easy;
        // 0.8 - 1.1 = evenly
        if (t / o >= 0.8f && t / o <= 1.1f) return WinRatio.Evenly_matched;
        // 1.1 - 1.3 = hard
        if (t / o > 1.1f && t / o <= 1.3f) return WinRatio.Hard;
        // 1.3+ = impossible
        return WinRatio.Impossible;
    }

    /// <summary>
    /// Fights
    /// </summary>
    /// <param name="p"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public bool Fight(int p, int m)
    {
        // add -15 to 10% to either might to make it more random 

        int mm = (int)Random.Range(magicalMight * 0.85f, magicalMight * 1.1f);
        int pm = (int)Random.Range(physicalMight * 0.85f, physicalMight * 1.1f);

        // Your physical might must exceed
        // Your magical might must exceed
        // Your total must exceed
        if (p >= pm && m >= mm && p + m > pm + mm)
        {
            // win
            return true;
        } else
        {
            // lose
            return false;
        }
    }

    /// <summary>
    /// Loot the enemy
    /// </summary>
    /// <returns></returns>
    public Loot Loot()
    {
        return loot;
    }

    public enum WinRatio
    {
        Easy,
        Evenly_matched,
        Hard,
        Impossible
    }
}