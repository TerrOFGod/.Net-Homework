using System.ComponentModel.DataAnnotations;

namespace HW7.Models
{
    public class UserProfile
    {
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Это обязательное поле!")]
        [RegularExpression(@"^[A-ZА-Я][a-zа-я]+$", 
            ErrorMessage = "Некорректная фамилия(принимаются только буквенные значения, начинающиеся с заглавной).")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Это обязательное поле!")]
        [RegularExpression(@"^[A-ZА-Я][a-zа-я]+$", 
            ErrorMessage = "Некорректное имя(принимаются только буквенные значения, начинающиеся с заглавной).")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [RegularExpression(@"^[A-ZА-Я][a-zа-я]+$", 
            ErrorMessage = "Некорректное отчество(принимаются только буквенные значения, начинающиеся с заглавной).")]
        public string Patronymic { get; set; }

        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Это обязательное поле!")]
        [Range(0, 110, ErrorMessage = "Неккоректный возраст(не должен превышать 110 лет и быть меньше 0).")]
        public int? Age { get; set; }
    }

    public enum Sex
    {
        [Display(Name = "Мужчина")]
        Male,
        [Display(Name = "Женщина")]
        Female
    }
}