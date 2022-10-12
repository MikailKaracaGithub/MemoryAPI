namespace MemoryWebApi.Models
{
    public class PlayerRepository
    {
        public Player Add(Player player)
        {
            MemoryContext ctx = new MemoryContext();
            ctx.Players.Add(player);
            ctx.SaveChanges();

            return player;
        }
    }
}
