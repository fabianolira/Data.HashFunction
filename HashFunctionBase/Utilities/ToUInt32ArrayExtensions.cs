﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.HashFunction.Utilities
{
    /// <summary>
    /// Static class to provide ToUInt32Array extension functions.
    /// </summary>
    internal static class ToUInt32ArrayExtensions
    {
        /// <summary>
        /// Converts a BigInteger to an array of UInt32 values.
        /// </summary>
        /// <param name="value">BigInteger to be converted.</param>
        /// <param name="bitSize">Expected bit-length of resulting array.  Must be a positive multiple of 32.</param>
        /// <returns>Array of UInt32 values representing the BigInteger value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32[] ToUInt32Array(this BigInteger value, int bitSize)
        {
            if (bitSize < 0 || bitSize % 32 != 0)
                throw new ArgumentOutOfRangeException("bitSize", "bigSize must be a positive a multiple of 32.");

            var uint32Values = new UInt32[bitSize / 32];
            var bigIntegerBytes = value.ToByteArray();


            var copyLength = uint32Values.Length * 4;

            if (bigIntegerBytes.Length < copyLength)
                copyLength = bigIntegerBytes.Length;


            Buffer.BlockCopy(
                bigIntegerBytes, 0,
                uint32Values, 0,
                copyLength);

            return uint32Values;
        }
    }
}