﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weibo.Entity;

namespace Weibo.Web.Models
{
    public class VotesModel
    {
        public IList<Vote> Votes { get; set; }
    }
}