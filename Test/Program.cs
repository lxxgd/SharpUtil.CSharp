using SharpUtil;
using SharpUtil.Command;
using SharpUtil.Data.Tag;
using SharpUtil.Logging;
using System.Reflection;

namespace Test
{
    public class Program
    {
        public static TestSaveData data = new TestSaveData();
        public static readonly SimpleLogger logger = new SimpleLogger("Main","./logs/");
        public static bool running;
        public static readonly CommandManager commandManager = new CommandManager();

        private static void Main()
        {
            Thread.CurrentThread.Name = "main thread";
            running = true;
            commandManager.Register(new ExitCommand());
            commandManager.Register(new PrintDirectoryCommand());
            commandManager.Register(new PrintDataTagCommand());
            Console.WriteLine("Hello, World!");
            data.uuid.Add(new Guid("976c95e5-bae7-493c-a087-61158d75598a"));
            data.uuid.Add(new Guid("3d5d1df5-3c01-4ba7-9c34-e6c87b3bae9c"));
            data.uuid.Add(new Guid("66bf2d19-ab7d-447c-a6a8-0e7e9f6f0b71"));
            Console.WriteLine((int)(OutputConditionFlags.Anchored | OutputConditionFlags.Thermal));
            data.anInt = 114514;
            data.anInt2 = 666;
            data.anInt3 = int.MaxValue;
            data.str = "aaa";
            data.de = 15;
            data.Save();
            data = new TestSaveData();
            logger.Info(StringUtil.GetRandomString2(32));
            data.Load();
            try
            {
            }
            catch(Exception ex) 
            {
                logger.Error(ex.GetExceptionMessage());
            }
            while (running)
            {
                string? input =  Console.ReadLine();
                if(!string.IsNullOrEmpty(input) && input[0] != ' ')
                    commandManager.Execute(input);
            }
        }

        static void method() 
        {
            Test t = new Test();

        }

        struct Test
        {
            public int max;
            public int Min { get; set; } = 15;

            public Test() { this.max = 16;}
        }

        public enum CheatCode
        {
            // Token: 0x04003D9B RID: 15771
            ToggleDevelopmentCheats,
            // Token: 0x04003D9C RID: 15772
            ToggleDevelopmentCheatsPublic,
            // Token: 0x04003D9D RID: 15773
            TogglePublicFacingCheats1,
            // Token: 0x04003D9E RID: 15774
            TogglePublicFacingCheats2,
            // Token: 0x04003D9F RID: 15775
            TogglePublicFacingCheats3,
            // Token: 0x04003DA0 RID: 15776
            TogglePublicFacingCheats4,
            // Token: 0x04003DA1 RID: 15777
            TogglePublicFacingCheats5,
            // Token: 0x04003DA2 RID: 15778
            Skip,
            // Token: 0x04003DA3 RID: 15779
            Attract,
            // Token: 0x04003DA4 RID: 15780
            HideUI,
            // Token: 0x04003DA5 RID: 15781
            ShowUI,
            // Token: 0x04003DA6 RID: 15782
            Replace,
            // Token: 0x04003DA7 RID: 15783
            Reload,
            // Token: 0x04003DA8 RID: 15784
            Currency,
            // Token: 0x04003DA9 RID: 15785
            LargeCurrency,
            // Token: 0x04003DAA RID: 15786
            HideCursor,
            // Token: 0x04003DAB RID: 15787
            ShowCursor,
            // Token: 0x04003DAC RID: 15788
            NoNight,
            // Token: 0x04003DAD RID: 15789
            SkipToNextDayOrNight,
            // Token: 0x04003DAE RID: 15790
            Immortal,
            // Token: 0x04003DAF RID: 15791
            FlipReverseSteering,
            // Token: 0x04003DB0 RID: 15792
            ToggleFPS,
            // Token: 0x04003DB1 RID: 15793
            RandD,
            // Token: 0x04003DB2 RID: 15794
            InvaderInfo,
            // Token: 0x04003DB3 RID: 15795
            DevelopmentBlocks,
            // Token: 0x04003DB4 RID: 15796
            PrintingEnabled,
            // Token: 0x04003DB5 RID: 15797
            SaveSequence,
            // Token: 0x04003DB6 RID: 15798
            AllowLoadAllSaves,
            // Token: 0x04003DB7 RID: 15799
            AddXP_GSO,
            // Token: 0x04003DB8 RID: 15800
            AddXP_GEO,
            // Token: 0x04003DB9 RID: 15801
            AddXP_VEN,
            // Token: 0x04003DBA RID: 15802
            AddXP_HWK,
            // Token: 0x04003DBB RID: 15803
            AddXP_BF,
            // Token: 0x04003DBC RID: 15804
            ToggleXP,
            // Token: 0x04003DBD RID: 15805
            SpawnAI,
            // Token: 0x04003DBE RID: 15806
            UnlockBlocks,
            // Token: 0x04003DBF RID: 15807
            PauseEnemies,
            // Token: 0x04003DC0 RID: 15808
            PauseTime,
            // Token: 0x04003DC1 RID: 15809
            CompleteEncounter,
            // Token: 0x04003DC2 RID: 15810
            ResetAchievements,
            // Token: 0x04003DC3 RID: 15811
            NoScenery,
            // Token: 0x04003DC4 RID: 15812
            ShowTechCost,
            // Token: 0x04003DC5 RID: 15813
            ExclusiveContent,
            // Token: 0x04003DC6 RID: 15814
            SkipMultiplayerTimer,
            // Token: 0x04003DC7 RID: 15815
            MaxPower,
            // Token: 0x04003DC8 RID: 15816
            ThrowException,
            // Token: 0x04003DC9 RID: 15817
            NetDump,
            // Token: 0x04003DCA RID: 15818
            ToggleBlockLimiter,
            // Token: 0x04003DCB RID: 15819
            SpawnAllMissions,
            // Token: 0x04003DCC RID: 15820
            RemoveTechLoaderRestrictions,
            // Token: 0x04003DCD RID: 15821
            DebugPlacementIntersections,
            // Token: 0x04003DCE RID: 15822
            NoDamage,
            // Token: 0x04003DCF RID: 15823
            PauseMissionTimer,
            // Token: 0x04003DD0 RID: 15824
            AddXP_RR,
            // Token: 0x04003DD1 RID: 15825
            GravityNormal,
            // Token: 0x04003DD2 RID: 15826
            FastTalk,
            // Token: 0x04003DD3 RID: 15827
            AllEnemies,
            // Token: 0x04003DD4 RID: 15828
            TogglePopInfo,
            // Token: 0x04003DD5 RID: 15829
            ToggleTradingStationDebug,
            // Token: 0x04003DD6 RID: 15830
            TogglePowerLevels,
            // Token: 0x04003DD7 RID: 15831
            EncounterState,
            // Token: 0x04003DD8 RID: 15832
            AddBigXP_GSO,
            // Token: 0x04003DD9 RID: 15833
            AddBigXP_GEO,
            // Token: 0x04003DDA RID: 15834
            AddBigXP_VEN,
            // Token: 0x04003DDB RID: 15835
            AddBigXP_HWK,
            // Token: 0x04003DDC RID: 15836
            AddBigXP_BF,
            // Token: 0x04003DDD RID: 15837
            AddBigXP_RR,
            // Token: 0x04003DDE RID: 15838
            UnlimitedShopBlocks,
            // Token: 0x04003DDF RID: 15839
            AllBlocksInInventory,
            // Token: 0x04003DE0 RID: 15840
            SyncMap,
            // Token: 0x04003DE1 RID: 15841
            AddXP_SJ,
            // Token: 0x04003DE2 RID: 15842
            AddBigXP_SJ
        }
    }
}
