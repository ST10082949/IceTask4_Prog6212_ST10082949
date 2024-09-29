using System;
using System.ComponentModel.DataAnnotations;


namespace TaskManagementApp_ST10082949.Models

{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Deadline is required.")]
        public DateTime Deadline { get; set; }
    }
}
