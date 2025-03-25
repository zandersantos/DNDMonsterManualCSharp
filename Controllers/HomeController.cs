using DungeonsAndDragonsMonsterManualCSharp.Data;
using DungeonsAndDragonsMonsterManualCSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;

namespace DungeonsAndDragonsMonsterManualCSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public IActionResult Index()
        {

            var connectionString = _configuration.GetConnectionString("DungeonsAndDragonsMonsterManualCSharpContext");

            // Fetch top 10 actions
            var topActions = new List<TopActionViewModel>();
            var topActionsQuery = @"
                SELECT TOP 10 
                    A.Id AS ActionId, 
                    A.Name AS ActionName, 
                    COUNT(MA.MonsterId) AS MonsterCount
                FROM MonsterAction MA
                JOIN Action A ON MA.ActionId = A.Id
                GROUP BY A.Id, A.Name
                ORDER BY MonsterCount DESC";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(topActionsQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            topActions.Add(new TopActionViewModel
                            {
                                Id = reader.GetInt32(0),
                                ActionName = reader.GetString(1),
                                MonsterCount = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            // Fetch top 3 senses
            var topSenses = new List<TopSenseViewModel>();
            var topSensesQuery = @"
                SELECT TOP 3 
                    S.Id AS SenseId, 
                    S.SenseType AS SenseType, 
                    COUNT(MS.MonsterId) AS MonsterCount
                FROM MonsterSense MS
                JOIN Sense S ON MS.SenseId = S.Id
                GROUP BY S.Id, S.SenseType
                ORDER BY MonsterCount DESC";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(topSensesQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            topSenses.Add(new TopSenseViewModel
                            {
                                Id = reader.GetInt32(0),
                                SenseType = reader.GetString(1),
                                MonsterCount = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            ViewData["TopActions"] = topActions;
            ViewData["TopSenses"] = topSenses;
            return View();
        }

      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
