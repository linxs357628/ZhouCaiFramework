using FluentValidation;
using ZhouCaiFramework.Model.Dtos;

namespace ZhouCaiFramework.Web.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("用户名不能为空")
                .Length(4, 20).WithMessage("用户名长度必须在4-20个字符之间");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密码不能为空");
                //.MinimumLength(8).WithMessage("密码长度不能少于8位")
                //.Matches("[A-Z]").WithMessage("密码必须包含至少一个大写字母")
                //.Matches("[a-z]").WithMessage("密码必须包含至少一个小写字母")
                //.Matches("[0-9]").WithMessage("密码必须包含至少一个数字")
                //.Matches("[^a-zA-Z0-9]").WithMessage("密码必须包含至少一个特殊字符");
        }
    }
}
