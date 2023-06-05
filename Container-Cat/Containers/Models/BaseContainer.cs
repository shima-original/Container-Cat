﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Container_Cat.Containers.Models
{
    public class BaseContainer
    {
        [Key]
        public string Id { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Port> Ports { get; set; }
        public List<Mount> Mounts { get; set; }
    }
    public class Port
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string IP { get; set; }
        public int PrivatePort { get; set; }
        public int PublicPort { get; set; }
        public string Type { get; set; }
    }
    public class Mount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool RW { get; set; }
    }
}
