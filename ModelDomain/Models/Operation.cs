﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    
    public class Operation
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ISet<OperationResult> OperationResults { get; set; }
    }
}