using UnityEngine;


static class RandomHash
{
    [SerializeField]
    private static uint seed = 0xABCDEF11;

    static uint BIT_NOISE1 = 0xB5297A4D;
    static uint BIT_NOISE2 = 0x68E31DA4;
    static uint BIT_NOISE3 = 0x1B56C4E9;

    public static uint Hash(params int[] args)
    {
        const uint PARAM_MASK = 0b11111;

        uint concatParams = 0;
        int i = 0;

        foreach (uint arg in args)
        {
            concatParams |= (arg & PARAM_MASK) << i;
            i += 5;
       }

        uint mangled = concatParams;
        mangled *= BIT_NOISE1;
        mangled += seed;
        mangled ^= (mangled >> 8);
        mangled += BIT_NOISE2;
        mangled ^= (mangled << 8);
        mangled *= BIT_NOISE3;
        mangled ^= (mangled >> 8);
        return mangled;
    }
}