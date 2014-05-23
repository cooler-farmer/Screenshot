using System;

namespace Screenshot.Windows
{
    [Flags]
    public enum TernaryRasterOperations : uint
    {
        SRCCOPY = 0x00CC0020,
        CAPTUREBLT = 0x40000000
    }
}