﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcUI.Models
{
    public class Question
    {
        [Display(Name = "Question id")]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Subject id")]
        [HiddenInput(DisplayValue = false)]
        public int SubjectId { get; set; }

        [Display(Name = "Test id")]
        [HiddenInput(DisplayValue = false)]
        public int TestId { get; set; }

        [Required]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Подтема")]
        public string Topic { get; set; }

        [Required]
        [Display(Name = "Уровень")]
        public int Level { get; set; }

        [Display(Name = "Пример")]
        public string Example { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
