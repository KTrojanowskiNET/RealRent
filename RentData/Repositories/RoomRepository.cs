using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RentData.IRepos;
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentData.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Room AddRoom(Room room)
        {
            dbContext.Rooms.Add(room);
            return room;
        }

        public void DeleteRoom(int id)
        {
            var rm = dbContext.Rooms.Find(id);
            if (rm != null)
            {
                dbContext.Remove(rm);
            }
        }

        public void EditRoom(Room room)
        {
            if (room != null)
            {
                dbContext.Rooms.Attach(room);
                dbContext.Entry(room).State = EntityState.Modified;

            }
        }

        public Room GetRoom(int id)
        {
           var rm = dbContext.Rooms.Find(id);
            return rm;
        }

       
        public Room GetRoom(string name)
        {
            var rm = dbContext.Rooms.FirstOrDefault(r => r.Name == name);
            return rm;
        }

        public IEnumerable<Room> GetRooms()
        {
            var rooms = dbContext.Rooms.AsNoTracking();
            return rooms;
        }
    }
}
