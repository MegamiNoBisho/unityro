﻿using System;
using System.Collections.Generic;

public partial class ZC {

    [PacketHandler(HEADER, "ZC_SKILLINFO_LIST")]
    public class SKILLINFO_LIST : InPacket {

        private const int BLOCK_SIZE = 37;
        public const PacketHeader HEADER = PacketHeader.ZC_SKILLINFO_LIST;

        public List<SkillInfo> skills = new List<SkillInfo>();

        public bool Read(BinaryReader br) {
            var count = Math.Max(0, (br.Length - br.Position) / BLOCK_SIZE);

            for(int i = 0; i < count; i++) {
                var skill = new SkillInfo() {
                    SkillID = br.ReadShort(),
                    SkillType = br.ReadLong(),
                    Level = br.ReadShort(),
                    SpCost = br.ReadShort(),
                    AttackRange = br.ReadShort(),
                    SkillName = br.ReadBinaryString(24),
                    CanUpgrade = br.ReadByte() == 1
                };

                skills.Add(skill);
            }

            return true;
        }
    }
}
