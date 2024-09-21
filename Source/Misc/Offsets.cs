namespace Offsets
{
    public struct Miscellaneous
    {
        public const uint LevelName = 0x18356c4; //[Miscellaneous]->LevelName
        public const uint Gamemode = 0x0246c460;    //mp_gamemode
        public const uint LocalPlayer = 0x24342B8; //[Miscellaneous]->LocalPlayer
        public const uint EntityList = 0x01f60fa0 + 0xA8; //[Miscellaneous]->cl_entitylist
        public const uint NameList = 0xd425fe0; //[Miscellaneous]->NameList
        public const uint ViewRender = 0x76e8738; //[Miscellaneous]->ViewRender
        public const uint ViewMatrix = 0x11a350; //[Miscellaneous]->ViewMatrix
    }
    
    public struct NameList
    {
        public const uint Index = 0x38; //nameIndex
    }

    public struct Player
    {
        public const uint Model = 0x0030; //m_ModelName
        public const uint WeaponHandle = 0x1944; //[RecvTable.DT_BaseCombatCharacter]->m_latestPrimaryWeapons
        public const uint OffWeaponHandle = 0x1954; //[RecvTable.DT_BaseCombatCharacter]->m_latestNonOffhandWeapons
        public const uint LastVisibleTime = 0x19a0; //[Miscellaneous]->CPlayer!lastVisibleTime
        public const uint LastAimedAtTime = 0x19a8; //[Miscellaneous]->CWeaponX!lastCrosshairTargetTime
        public const uint TimeBase = 0x2088; //[DataMap.C_Player]->m_currentFramePlayer.timeBase
        public const uint LifeState = 0x0690; //[RecvTable.DT_Player]->m_lifeState
        public const uint Health = 0x0328; //[RecvTable.DT_Player]->m_iHealth
        public const uint MaxHealth = 0x0470; //[RecvTable.DT_Player]->m_iMaxHealth
        public const uint Shield = 0x01a0; //[RecvTable.DT_TitanSoul]->m_shieldHealth
        public const uint MaxShield = 0x01a4; //[RecvTable.DT_TitanSoul]->m_shieldHealthMax
        public const uint Name = 0x0481; //[RecvTable.DT_BaseEntity]->m_iName
        public const uint BleedoutState = 0x2760; //[RecvTable.DT_Player]->m_bleedoutState
        public const uint XP = 0x3724; //[RecvTable.DT_Player]->m_xp
        public const uint Yaw = 0x223c - 0x8; //[DataMap.C_Player]->m_currentFramePlayer.m_ammoPoolCount - 0x8
        public const uint ViewAngles = 0x2534 - 0x14; //[DataMap.C_Player]->m_ammoPoolCapacity - 0x14
        public const uint SkyDiveStatus = 0x4784; //m_skydiveState
        public const uint ViewModel = 0x2d98;   //m_hViewModels
    }

    public struct Weapon
    {
        public const uint Index = 0x1788; //[RecvTable.DT_WeaponX]->m_weaponNameIndex
        public const uint Skin = 0x0d68; //m_nSkin
    }

    public struct BaseEntity
    {
        public const uint Position = 0x017c; //[DataMap.C_BaseEntity]->m_vecAbsOrigin
        public const uint TeamID = 0x0338; //[RecvTable.DT_BaseEntity]->m_iTeamNum
        public const uint SquadID = 0x0344; //[RecvTable.DT_BaseEntity]->m_squadID
        public const uint Name = 0x0481; //[RecvTable.DT_BaseEntity]->m_iName
    }

    public struct Glow
    {
        public const uint HighlightTypeSize = 0x34;
        public const uint ThroughWall = 0x26c; //Script_Highlight_SetVisibilityType
        public const uint Fix = 0x268;
        public const uint Highlight_ID = 0x29c; //[DT_HighlightSettings].m_highlightServerActiveStates
        public const uint Highlights = 0xB1DA220; //HighlightSettings
        public const uint Enable = 0x28C; //Script_Highlight_GetCurrentContext
    }

    public struct Spectator
    {
        public const uint List = 0x01f60fa0 + 0x20C8; //IDA signature >> [48 8B 0D ? ? ? ? 48 85 C9 74 ? 48 8B 01 FF ? ? 48 85 C0 74 ? 48 63 4E 38]
        public const uint Aux = 0x974;
    }
}