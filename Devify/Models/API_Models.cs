﻿namespace Devify.Models
{
    public class API_Model
    {
    }
    public class API_Response_VM
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}