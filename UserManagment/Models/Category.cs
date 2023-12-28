using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserManagment.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="عنوان دسته اجباری می باشد")]
        [DisplayName("عنوان دسته")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ترتیب نمایش اجباری می باشد")]
        [DisplayName("ترتیب نمایش")]
        [Range(1,100, ErrorMessage="از یک تا 100 قابل قبول است")]
        public int Displayoreder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
