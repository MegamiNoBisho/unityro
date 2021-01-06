﻿using System;
public partial class ZC {

    [PacketHandler(HEADER, "ZC_ACK_TAKEOFF_EQUIP_V5", SIZE)]
    public class ACK_TAKEOFF_EQUIP_V5 : InPacket {

        public const PacketHeader HEADER = PacketHeader.ZC_ACK_TAKEOFF_EQUIP_V5;
        public const int SIZE = 9;

        public int index;
        public int equipLocation;
        public int result;

        public bool Read(BinaryReader br) {

            index = br.ReadShort();
            equipLocation = br.ReadLong();
            result = br.ReadByte();

            return true;
        }
    }
}