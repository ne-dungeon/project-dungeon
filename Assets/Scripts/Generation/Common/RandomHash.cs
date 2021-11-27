using UnityEngine;


static class RandomHash
{
    [SerializeField]
    private int seed = 0xABCDEF12;

    const int BIT_NOISE1 = 0xB5297A4D;
    const int BIT_NOISE2 = 0x68E31DA4;
    const int BIT_NOISE3 = 0x1B56C4E9;

    public int Hash(params int[] args)
    {
        const int PARAM_MASK = 0b11111;

        int concatParams = 0;
        int i = 0;

        foreach (int arg in args)
        {
            concatParams |= (arg & PARAM_MASK) << i;
            i += 5;
        }

        unsigned int mangled = position;
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