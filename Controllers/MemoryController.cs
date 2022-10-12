using MemoryWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MemoryWebApi.Controllers
{
    //Scaffold-DbContext "Server=LocalHost;Database=Memory;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
    //Server=LocalHost;Database=Memory;User Id=memorryapi;Password=password

    [ApiController]
    [Route("[controller]")]
    public class MemoryController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetImage(int id)
        {
            MemoryContext context = new MemoryContext();
            byte[] image = context.Images.Where(i => i.Id == id).Select(i => i.Image1).First();
            Response.ContentType = "image/png";
            return File(image, "image/png");
        }

        [HttpGet("")]
        public IEnumerable<Image> Get()
        {
            MemoryContext context = new MemoryContext();
            return context.Images;
        }
        [HttpGet("Back")]
        public IActionResult GetBack()
        {
            MemoryContext context = new MemoryContext();
            byte[] image = context.Images.Where(i => i.IsBack == true).Select(i => i.Image1).First();
            Response.ContentType = "image/png";
            return File(image, "image/png");
        }

        [HttpGet("theme/{theme}")]
        public IEnumerable<Image> GetByTheme(string theme)
        {
            MemoryContext context = new MemoryContext();
            return context.Images.Where(i => i.Theme == theme);
        }

        [HttpGet("Back/{theme}")]
        public IActionResult GetThemeBack(string theme)
        {
            MemoryContext context = new MemoryContext();
            byte[] image = context.Images.Where(i => i.Theme == theme && i.IsBack == true).Select(i => i.Image1).First();
            Response.ContentType = "image/png";
            return File(image, "image/png");
        }
        [HttpPost("Player")]
        public Player PostPlayer([FromBody] Player player)
        {
            PlayerRepository repo = new PlayerRepository();
            return repo.Add(player);
        }

        [HttpGet("Player/{id}")] //swagger get single one
        public Player GetPlayer(int id)
        {
            MemoryContext context = new MemoryContext();
            Player player = context.Players.Where(i => i.PlayerId == id).First();
            return player;
        }

        [HttpGet("Player")] //swagger get everything
        public IEnumerable<Player> GetPlayers()
        {
            MemoryContext context = new MemoryContext();
            return context.Players;
        }
    }
}