public User GetUserById(int id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }
