﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface UserService {
        User findUserById(string userId);
        void updateUser(User usr);
        void insertUser(User usr);
        void insertPendingUser(User usr);
    }
}