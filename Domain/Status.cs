﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Status
    {
        public Int32 Status_ID;
        public string Status_name;
        public ICollection<Task> Tasks;
    }
}