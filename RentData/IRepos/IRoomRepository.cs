using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentData.IRepos
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetRooms();
        public Room GetRoom(int id);
        public Room GetRoom(string name);
        public Room AddRoom(Room room);
        public void EditRoom(Room room);
        public void DeleteRoom(int id);
       
    }
}
