using FluentValidation;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Validators
{
    public class UserAccountCreateDtoValidator : AbstractValidator<UserAccountCreateDto>
    {
        public UserAccountCreateDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("用户名不能为空")
                .Length(4, 20).WithMessage("用户名长度必须为4-20个字符")
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("用户名只能包含字母、数字和下划线");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .MinimumLength(8).WithMessage("密码长度不能少于8位")
                .Matches("[A-Z]").WithMessage("密码必须包含至少1个大写字母")
                .Matches("[a-z]").WithMessage("密码必须包含至少1个小写字母")
                .Matches("[0-9]").WithMessage("密码必须包含至少1个数字")
                .Matches("[^a-zA-Z0-9]").WithMessage("密码必须包含至少1个特殊字符");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("手机号不能为空")
                .Matches(@"^1[3-9]\d{9}$").WithMessage("手机号格式不正确");
        }
    }
}