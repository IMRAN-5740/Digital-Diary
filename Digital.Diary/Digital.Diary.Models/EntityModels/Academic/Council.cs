﻿using Digital.Diary.Models.BaseEntityModel;
using Digital.Diary.Models.EntityModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Models.EntityModels.Academic
{
    [Table(nameof(Council), Schema = "Academic")]
    public class Council:BaseUserTable
    {
        [DisplayName("Designation Name")]
        public Guid DesignationId { get; set; } = default!;
        public Designation Designation { get; set; } = default!;

    }
}