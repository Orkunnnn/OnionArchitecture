﻿namespace OnionArchitecture.Api.HealthCheck
{
    public class HealthCheck
    {
        public string Status { get; set; } = default!;
        public string Component { get; set; } = default!;
        public string? Description { get; set; }
    }
}
