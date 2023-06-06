using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Reflection;

namespace BASTool.Models
{
    public enum GameIdEnum
    {
        None = 0,

        [Description("新建")]
        New = 0xFFFFFF,

        [Description("原神")]
        GI = 4963,

        [Description("崩坏：星穹铁道")]
        HKSR = 7840,

#if DEBUG
        [Description("测试")]
        Test = 6657,
#endif
    }

    public class Game : ObservableObject
    {
        private string _Name;
        private readonly static Game _noneGame = new() { Id = (int)GameIdEnum.None, Name = string.Empty };
        private readonly static Game _newGame = new() { Id = (int)GameIdEnum.New, Name = GameIdEnum.New.GetDescription() };

        public static Game noneGame => _noneGame;
        public static Game newGame => _newGame;

        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }
        public int Id { get; set; }
    }

    public static class Extension
    {
        public static string GetDescription(this GameIdEnum game, int i = 0)
        {
            Type type = typeof(GameIdEnum);
            FieldInfo? info = type.GetField(game.ToString());
            DescriptionAttribute?[]? descriptionAttributes = (DescriptionAttribute?[]?)info?.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (descriptionAttributes?.Length > i)
                return descriptionAttributes[i]!.Description;
            else
                return game.ToString();
        }
    }
}
