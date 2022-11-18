using FluentValidation;


namespace Validators
{
    public class UpdateGradeRequestValidator : AbstractValidator<StudentManagement.Models.DTOs.UpdateGradeRequest>
    {
        public UpdateGradeRequestValidator()
        {
            RuleFor(x=>x.GradeName).NotEmpty();
            RuleFor(x=>x.Section).NotEmpty();
        }
    }
    
}