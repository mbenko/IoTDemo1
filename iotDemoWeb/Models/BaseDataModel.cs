using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iotDemoWeb.Models
{
    public class BaseDataModel : ITableData
    {
        [Key]
        [TableColumn(TableColumnType.Id)]
        [MaxLength(36)]
        public string Id { get; set; }

        [TableColumn(TableColumnType.Version)]
        [Timestamp]
        public byte[] Version { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [TableColumn(TableColumnType.CreatedAt)]
        public DateTimeOffset? CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [TableColumn(TableColumnType.UpdatedAt)]
        public DateTimeOffset? UpdatedAt { get; set; }


        [TableColumn(TableColumnType.Deleted)]
        public bool Deleted { get; set; }
    }
}