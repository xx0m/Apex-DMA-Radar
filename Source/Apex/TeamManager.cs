using SkiaSharp;

namespace apex_dma_radar
{
    public class TeamManager
    {
        public static Dictionary<int, List<Player>> Teams = new Dictionary<int, List<Player>> ();

        private static readonly SKColor[] Colors = new SKColor[]
        {
            new SKColor(255, 179, 186),  // Pastel Pink
            new SKColor(255, 223, 186),  // Pastel Orange
            new SKColor(255, 255, 186),  // Pastel Yellow
            new SKColor(186, 255, 201),  // Pastel Green
            new SKColor(186, 225, 255),  // Pastel Blue
            new SKColor(223, 186, 255),  // Pastel Purple
            new SKColor(255, 186, 255),  // Pastel Magenta
            new SKColor(255, 186, 213),  // Light Pink
            new SKColor(255, 213, 186),  // Light Peach
            new SKColor(226, 255, 186),  // Light Lime
            new SKColor(186, 255, 233),  // Light Aqua
            new SKColor(186, 196, 255),  // Light Sky Blue
            new SKColor(205, 186, 255),  // Light Lavender
            new SKColor(255, 240, 179),  // Light Gold
            new SKColor(179, 255, 226),  // Mint
            new SKColor(255, 204, 153),  // Light Salmon
            new SKColor(204, 255, 153),  // Light Yellow-Green
            new SKColor(153, 255, 204),  // Light Turquoise
            new SKColor(153, 204, 255),  // Light Azure
            new SKColor(204, 153, 255)   // Light Orchid
        };

        public static SKColor GetTeamColor(int teamID)
        {
            return TeamManager.Colors[(teamID - 1) % TeamManager.Colors.Length];
        }

        public static void AddTeamMember(Player player)
        {
            var key = player.TeamID;

            if (TeamManager.Teams.ContainsKey(key))
            {
                if (!Teams[key].Contains(player))
                    TeamManager.Teams[key].Add(player);
            }
            else
                TeamManager.Teams[key] = new List<Player> { player };
        }

        public static List<Player> GetTeamMembers(int teamID)
        {
            return TeamManager.Teams.TryGetValue(teamID, out var members) ? members : new List<Player>();
        }

        public static bool IsLastAlive(Player player)
        {
            var teamMembers = TeamManager.GetTeamMembers(player.TeamID);

            if (teamMembers.Count == 0 || (teamMembers.Count == 1 && teamMembers[0] == player))
                return true;

            if (player.IsDead || player.IsKnocked)
                return false;

            return teamMembers.Count(teammate => !teammate.IsDead && !teammate.IsKnocked) == 1;
        }

        public static void Reset()
        {
            TeamManager.Teams.Clear();
        }
    }
}
