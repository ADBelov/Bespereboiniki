using System;

namespace Bespereboiniki.Datalayer.Tables
{
    public class UPS
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; }

        public int Uin { get; set; }

        public int Uout { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Length { get; set; }

        public int Capacity { get; set; }
    }
}