using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomWebApp.Models;

namespace RoomWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public object Create([FromBody] RoomInfoRequest room)
        {
            if (room.Height <= 0 || room.Width <= 0 || room.Length <= 0 || room.PaintArea <= 0)
                return StatusCode(400);

            double wallArea = room.Height * room.Length * 2 +
                              room.Height * room.Width * 2;

            return new
            {
                area = room.Width * room.Length,
                volume = room.Width * room.Length * room.Height,
                paintRequired = wallArea / room.PaintArea
            };
        }


    }
}
