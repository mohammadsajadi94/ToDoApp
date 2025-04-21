﻿namespace ToDoApp.Domain.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
